using System.ComponentModel.DataAnnotations;

namespace test_task.Models
{
    public enum CompanyForm
    {
        OOO,
        ZAO,
        AO,
        YP,
        RYP
    }
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Size {get; set; }
        [Required]
        public CompanyForm Form { get; set; }

    }
}
