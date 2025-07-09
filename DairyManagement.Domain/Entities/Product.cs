using System;
using System.Collections.Generic;

namespace DairyManagement.Infrastructure
{
    public partial class Product
    {
        public Product()
        {
            ClientOrders = new HashSet<ClientOrder>();
            Inventories = new HashSet<Inventory>();
            VendorSupplies = new HashSet<VendorSupply>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<ClientOrder> ClientOrders { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<VendorSupply> VendorSupplies { get; set; }
    }
}
