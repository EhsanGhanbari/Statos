using System;

namespace Statos.Service.Stores
{
    public class StoreViewModel
    {
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int NumberOfProduct { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string PurchaserName { get; set; }
        public string VendorName { get; set; }
        public string VendorCountry { get; set; }
        public string Price { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
