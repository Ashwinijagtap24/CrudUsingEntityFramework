using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsingEntityFramework.Models
{
    [Table("tblStudent")]
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Rollno { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Marks { get; set; }
        [Required]
        public string? City { get; set; }
    }
}
