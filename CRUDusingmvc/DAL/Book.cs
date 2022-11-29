using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace CRUDusingmvc.DAL

{
    [Table("b")]
    public class Book
    {
        [Key] //this is my primary key
        [ScaffoldColumn(false)]
        public int Id { get; set; } 
        public string? Name { get; set; }
        
        public int Price { get; set; }
    }
}
