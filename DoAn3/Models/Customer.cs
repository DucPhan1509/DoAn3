using System.ComponentModel.DataAnnotations;

namespace DoAn3.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string CreatedUser { get; set; } = "";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
