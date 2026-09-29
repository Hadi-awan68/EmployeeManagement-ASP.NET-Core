using EmployeeManagement.DTOs;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
       Task<List<EmployeeResponseDto>> GetEmployeesAsync();
        Task<EmployeeResponseDto?> CreateEmployeeAsync(CreateEmployeeDto employee);
        Task<EmployeeResponseDto?> UpdateEmployeeAsync(int Id, UpdateEmployeeDto employee);
        Task<bool> DeleteEmployeeAsync(int Id);
        Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int Id);


    }
}
