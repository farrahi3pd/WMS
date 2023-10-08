using System.ComponentModel.DataAnnotations;

namespace RegisterPeople.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        [Required]
        public DateTime ReceiptDate { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int NumberOfProducts { get; set; }
        [Required]
        public double PriceOfEachProduct { get; set; }
        [Required]
        public double TotalPriceOfReceipt { get; set; }
    }
}
