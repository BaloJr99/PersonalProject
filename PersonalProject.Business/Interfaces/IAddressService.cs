using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProject.Data.DTO;

namespace PersonalProject.Business.Interfaces
{
    public interface IAddressService
    {
        Task<AddressDTO> GetAddress(Guid idAddress);
    }
}