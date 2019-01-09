using System;
using System.Collections.Generic;
using Statos.Model.Products;

namespace Statos.Model.Stores
{
    public class Store : IAggregateRoot
    {
        public Guid Id { get; set; }

        //Number of product in the Store
        public int NumberOfProduct { get; set; }

        //Date of Purchase
        public DateTime PurchaseTime { get; set; }

        //Name of the Purchaser 
        public string PurchaserName { get; set; }

        //price of the product
        public string Price { get; set; }

        // totla price of the products
        public decimal TotalPrice { get; set; }


        public virtual ICollection<Product> Products { get; set; }

    }
}
