using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiForOrderManagementSystemUsingEFCodeFirst.Models
{
    public class CustomerMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName="varchar(40)")]
        public string? FirstName { get; set; }
        [Required,Column(TypeName="varchar(30)")]
        public string? LastName { get; set; }
        [Required, Column(TypeName="numeric")]
        public int? PhoneNumber { get; set; }
        [Required , Column(TypeName="varchar(50)")]
        public string? EmailAddress { get; set; } 



    }
}
