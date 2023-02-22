using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsingEntityFramework.Models
{
    [Table("tblProduct2")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Price{ get; set; }
        [Required]
        public string? Company { get; set; }
    }
}
