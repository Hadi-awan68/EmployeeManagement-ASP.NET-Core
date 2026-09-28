using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var employees = await _context.Employees.AsNoTracking().ToListAsync();

            return employees;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
             _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateEmployeeAsync(int Id, Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(Id);

            if (existingEmployee == null)
            {
                return null;

            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;

            await _context.SaveChangesAsync();

            return existingEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(int Id)
        {
            var existingEmployee = await _context.Employees.FindAsync(Id);

            if (existingEmployee == null)
            {
                return false;
            }

            _context.Employees.Remove(existingEmployee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int Id)
        {
            var employeeToFind = await _context.Employees.FindAsync(Id);

            if (employeeToFind == null)
            {
                return null;
            }

            return employeeToFind;


        }
    }
}