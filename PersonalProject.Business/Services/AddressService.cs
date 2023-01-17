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
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWorkPersonal _uok;
        private readonly IMapper _mapper;            

        public AddressService(IUnitOfWorkPersonal uok, IMapper mapper)
        {
            _uok = uok;
            _mapper = mapper;
        }

        public async Task<AddressDTO> GetAddress(Guid idAddress)
        {
            Address address = await _uok.GetRepository<Address>().GetByIdAsync(idAddress);
            return _mapper.Map<AddressDTO>(address);
        }
    }
}