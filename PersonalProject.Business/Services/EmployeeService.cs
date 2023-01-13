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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWorkPersonal _uok;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWorkPersonal uok, IMapper mapper)
        {
            _uok = uok;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            return _mapper.Map<IEnumerable<EmployeeDTO>>(await _uok.GetRepository<Employee>().GetAllAsync());
        }

        public async Task SaveEmployee(EmployeeDTO employeeDTO, AddressDTO addressDTO)
        {
            try
            {
                await _uok.CreateTransactionAsync();

                Address address = _mapper.Map<Address>(addressDTO);
                await _uok.GetRepository<Address>().AddAsync(address);
                await _uok.SaveChangesAsync();
            
                Employee employee = _mapper.Map<Employee>(employeeDTO);
                employee.IdAddress = address.IdAddress;
                await _uok.GetRepository<Employee>().AddAsync(employee);
                await _uok.SaveChangesAsync();

                await _uok.CommitAsync();
            }
            catch (System.Exception ex)
            {
                await _uok.RollbackAsync();
                throw new ApplicationException($"Ocurrio un error {ex.Message}");
            }
        }
    }
}