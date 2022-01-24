using System.ComponentModel.DataAnnotations;

namespace test_task.Models
{
    public abstract class Person
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
    }
}
