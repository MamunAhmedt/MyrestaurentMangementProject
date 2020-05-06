using System.ComponentModel.DataAnnotations;

namespace Resturant_Management.Models
{
  

    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public string PurchaseDate { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string Units { get; set; }
        public float UnitPrice { get; set; }
        public float NetAmount { get; set; }
        public float GrandTotal { get; set; }

      
    }
    




}
