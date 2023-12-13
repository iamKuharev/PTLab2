namespace TP_Shop.Models
{
    public class PurchaseViewModel
    {
        public long ProductId { get; set; }

        public string Person { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime Date { get; set; }
    }
}
