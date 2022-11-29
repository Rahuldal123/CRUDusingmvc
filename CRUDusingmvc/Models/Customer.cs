using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRUDusingmvc.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        [ScaffoldColumn(false)]
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]

        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string?  Email { get; set; }
        [Required(ErrorMessage = "Contact is Required")]
        public string? Contact { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
