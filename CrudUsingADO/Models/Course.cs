using System.ComponentModel.DataAnnotations;

namespace CrudUsingADO.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Fees { get; set; }
        [Required]
        public string? Duration { get; set; }
    }
}
