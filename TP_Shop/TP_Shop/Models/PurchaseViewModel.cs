using System.ComponentModel.DataAnnotations;

namespace TP_Shop.Models
{
    public class PurchaseViewModel
    {
        public long ProductId { get; set; }

        [Required]
        public string Person { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        public DateTime Date { get; set; }
    }
}
