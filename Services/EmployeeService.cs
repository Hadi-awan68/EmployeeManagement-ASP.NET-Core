using EmployeeManagement.Data;
using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(AppDbContext context, ILogger<EmployeeService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<List<EmployeeResponseDto>> GetEmployeesAsync()
        {
            var employees = await _context.Employees
                .Select(e => new EmployeeResponseDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Department = e.Department,
                    Salary = e.Salary
                })
                .ToListAsync();

            return employees;
        }

        public async Task<EmployeeResponseDto?> CreateEmployeeAsync(CreateEmployeeDto employee)
        {
            var existsEmail = await _context.Employees.AnyAsync(e => e.Email == employee.Email);

            if (existsEmail)
            {
                _logger.LogWarning("Attempt to create an employee with duplicate email : {Email}", employee.Email);
                return null;
            }

           

            var newEmployee = new Employee
            {
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                Salary = employee.Salary,
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Employee {EmployeeId} created successfully.", newEmployee.Id);

            var employeeResponse = new EmployeeResponseDto
            {
                Id = newEmployee.Id,
                Name = newEmployee.Name,
                Email = newEmployee.Email,
                Department = newEmployee.Department,
                Salary = newEmployee.Salary
            };
            return employeeResponse;
        }

        public async Task<EmployeeResponseDto?> UpdateEmployeeAsync(int Id, UpdateEmployeeDto employee)
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

            var employeeResponse = new EmployeeResponseDto
            {
                Id = existingEmployee.Id,
                Name = existingEmployee.Name,
                Email = existingEmployee.Email,
                Department = existingEmployee.Department,
                Salary = existingEmployee.Salary
            };

            return employeeResponse;
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

        public async Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id)
        {
            var employeeToFind = await _context.Employees.Where(e => e.Id == id)
                .Select(e => new EmployeeResponseDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Department = e.Department,
                    Salary = e.Salary,
                })
                .FirstOrDefaultAsync();

            return employeeToFind;
        }
    }
}