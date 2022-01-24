using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test_task.Models
{
    public enum Position
    {
        DEVELOPER,
        TESTER,
        BA,
        MANAGER
    }

    public class Employee  : Person
    {
        public int EmployeeId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        [Required]
        public Position Position { get; set; }
        [Required]
        public int CompanyId { get; set; }

        
    }
}
