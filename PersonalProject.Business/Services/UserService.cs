using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PersonalProject.Business.Interfaces;
using PersonalProject.Business.IUnitOfWork.Interfaces;
using PersonalProject.Data.DTO;
using PersonalProject.Data.Models;

namespace PersonalProject.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkPersonal _uok;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWorkPersonal uok, IMapper mapper)
        {
            _uok = uok;
            _mapper = mapper;
        }
        public async Task<UserDTO> GetUsuario(Guid id)
        {
            User user = await _uok.GetRepository<User>().GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}