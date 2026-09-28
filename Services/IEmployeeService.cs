using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
       Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee?> UpdateEmployeeAsync(int Id, Employee employee);
        Task<bool> DeleteEmployeeAsync(int Id);
        Task<Employee?> GetEmployeeByIdAsync(int Id);


    }
}
