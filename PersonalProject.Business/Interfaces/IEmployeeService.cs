using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProject.Data.DTO;

namespace PersonalProject.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        Task SaveEmployee(EmployeeDTO employeeDTO, AddressDTO addressDTO);
    }
}