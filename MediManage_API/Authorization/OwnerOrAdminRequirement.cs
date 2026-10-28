using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

public class OwnerOrAdminHandler
    : AuthorizationHandler<OwnerOrAdminRequirement, int>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        OwnerOrAdminRequirement requirement,
        int studentId)
    {
        if (context.User.IsInRole("511"))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (int.TryParse(userId, out int authenticatedStudentId) &&
            authenticatedStudentId == studentId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
