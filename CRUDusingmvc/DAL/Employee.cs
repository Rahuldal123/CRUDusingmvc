using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace CRUDusingmvc.DAL
{
    [Table("emp")]
    public class Employee
    {
        [Key] //this is my primary key
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
    }
}
