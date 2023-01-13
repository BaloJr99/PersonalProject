using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using PersonalProject.Data.DTO;

namespace PersonalProject.Business.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateToken(UserDTO user);
        public JwtSecurityToken ValidateToken(string token);
    }
}