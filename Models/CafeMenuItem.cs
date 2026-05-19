namespace CafeHandler.Models
{
    // Renamed from MenuItem to CafeMenuItem to avoid conflict
    // with System.Windows.Forms.MenuItem
    public class CafeMenuItem
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}