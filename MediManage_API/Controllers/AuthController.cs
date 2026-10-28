using MediManage_Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SharedDTOs;
using SharedDTOs.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.RateLimiting;

namespace MediManage_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration, ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("login")]
        [EnableRateLimiting("AuthLimiter")]
        public IActionResult Login([FromBody] LoginRequestDTO request)
        {
            var user = clsUser.Find(request.UserName);

            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            if (user == null)
            {
                _logger.LogWarning(
                    "Failed login attempt (UserName not found). UserName={UserName}, IP={IP}",
                    request.UserName,
                    ip
                );
                return Unauthorized("Invalid credentials");
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isValidPassword)
            {
                // [تعديل]: تم تصحيح رسالة الـ Log هنا أيضاً لتشير إلى UserName بدلاً من Email.
                _logger.LogWarning(
                    "Failed login attempt (bad password). UserName={UserName}, IP={IP}",
                    request.UserName,
                    ip
                );

                return Unauthorized("Invalid credentials");
            }

            var userIdClaimValue = user.UserID?.ToString() ?? string.Empty;
            var nameClaimValue = user.UserName ?? string.Empty;
            var roleClaimValue = user.Permissions?.ToString() ?? string.Empty;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userIdClaimValue),
                new Claim(ClaimTypes.Name, nameClaimValue),
                new Claim(ClaimTypes.Role, roleClaimValue)
            };

            var secretKey = _configuration["Jwt:Key"] ?? "THIS_IS_A_VERY_SECRET_KEY_123456";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"] ?? "MediManageIssuer",
                audience: _configuration["Jwt:Audience"] ?? "MediManageAudience",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            user.RefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(refreshToken);
            user.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
            user.RefreshTokenRevokedAt = null;
            user.Save();

            _logger.LogInformation(
                "Successful login. UserId={UserId}, UserName={UserName}, IP={IP}",
                user.UserID,
                user.UserName,
                ip
            );

            return Ok(new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        private static string GenerateRefreshToken()
        {
            var bytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        [HttpPost("refresh")]
        [EnableRateLimiting("AuthLimiter")]
        public IActionResult Refresh([FromBody] RefreshRequest request)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var user = clsUser.Find(request.UserName);

            if (user == null)
            {
                _logger.LogWarning(
                    "Invalid refresh attempt (UserName not found). UserName={UserName}, IP={IP}",
                    request.UserName,
                    ip
                );

                return Unauthorized("Invalid refresh request");
            }

            if (user.RefreshTokenRevokedAt != null)
            {
                _logger.LogWarning(
                    "Refresh attempt using revoked token. UserId={UserId}, UserName={UserName}, IP={IP}",
                    user.UserID,
                    user.UserName,
                    ip
                );

                return Unauthorized("Refresh token is revoked");
            }

            if (user.RefreshTokenExpiresAt == null || user.RefreshTokenExpiresAt <= DateTime.UtcNow)
            {
                _logger.LogWarning(
                    "Refresh attempt using expired token. UserId={UserId}, UserName={UserName}, IP={IP}",
                    user.UserID,
                    user.UserName,
                    ip
                );

                return Unauthorized("Refresh token expired");
            }

            bool refreshValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, user.RefreshTokenHash);

            if (!refreshValid)
            {
                _logger.LogWarning(
                    "Invalid refresh token attempt. UserId={UserId}, UserName={UserName}, IP={IP}",
                    user.UserID,
                    user.UserName,
                    ip
                );

                return Unauthorized("Invalid refresh token");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Permissions.ToString())
            };

            var secretKey = _configuration["Jwt:Key"] ?? "THIS_IS_A_VERY_SECRET_KEY_123456";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"] ?? "MediManageIssuer",
                audience: _configuration["Jwt:Audience"] ?? "MediManageAudience",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            var newAccessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(newRefreshToken);
            user.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
            user.RefreshTokenRevokedAt = null;
            user.Save();

            _logger.LogInformation(
                "Refresh succeeded. UserId={UserId}, UserName={UserName}, IP={IP}",
                user.UserID,
                user.UserName,
                ip
            );

            return Ok(new TokenResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromBody] LogoutRequestDTO request)
        {
            var user = clsUser.Find(request.UserName);

            if (user == null)
                return Ok();

            bool refreshValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, user.RefreshTokenHash);
            if (!refreshValid)
                return Ok();

            user.RefreshTokenRevokedAt = DateTime.UtcNow;
            user.Save();

            return Ok("Logged out successfully");
        }
    }
}