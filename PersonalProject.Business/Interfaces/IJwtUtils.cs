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
        string GenerateToken(UserDTO user);
        JwtSecurityToken ValidateToken(string token);
    }
}