using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiForOrderManagementSystemUsingEFCodeFirst.Models
{
    public class ItemMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required,Column(TypeName ="varchar(30)")]
        public string? Name { get; set; }
        [Required,Column(TypeName ="int")]
        public int? Price { get; set; }
        [Required,Column(TypeName ="int")]
        public int Quantity { get; set; }




    }
}
