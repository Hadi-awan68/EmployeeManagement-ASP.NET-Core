using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.DTOs
{
    public class CreateEmployeeDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
