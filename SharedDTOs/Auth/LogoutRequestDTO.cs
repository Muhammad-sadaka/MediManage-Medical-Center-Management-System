using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs.Auth
{
    public class LogoutRequestDTO
    {
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
    }
}
