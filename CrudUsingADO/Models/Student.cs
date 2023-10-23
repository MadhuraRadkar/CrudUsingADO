using System.ComponentModel.DataAnnotations;

namespace CrudUsingADO.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public double Percentage { get; set; }
    }
}
