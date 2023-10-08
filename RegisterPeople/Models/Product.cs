using System.ComponentModel.DataAnnotations;

namespace RegisterPeople.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ProductGroupId { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Stock { get; set; } // for stock controller
    }

}
