using System.ComponentModel.DataAnnotations;

namespace RegisterPeople.Models
{
    public class Sale
    {
        public int Id { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        public int ProductId { get; set; }
        public int NumberOfProducts { get; set; }
        public double PriceOfEachProduct { get; set; }
    }
}
