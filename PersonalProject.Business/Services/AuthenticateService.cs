using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalProject.Business.Interfaces;
using PersonalProject.Business.IUnitOfWork.Interfaces;
using PersonalProject.Data.DTO;
using PersonalProject.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace PersonalProject.Business.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUnitOfWorkPersonal _uok;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthenticateService(IUnitOfWorkPersonal uok, IMapper mapper, IConfiguration config)
        {
            _uok = uok;
            _mapper = mapper;
            _config = config;
        }
        public async Task<UserDTO> Authenticate(UserDTO user)
        {
            User? userResult = (await _uok.GetRepository<User>().GetWhereAsync(x => x.Username == user.Username && x.Password == user.Password)).FirstOrDefault();
            return _mapper.Map<UserDTO>(userResult);
        }

        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            await _uok.GetRepository<User>().AddAsync(user);
            await _uok.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }
    }
}