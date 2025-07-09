using System;
using System.Collections.Generic;

namespace DairyManagement.Infrastructure
{
    public partial class Vendor
    {
        public Vendor()
        {
            VendorSupplies = new HashSet<VendorSupply>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<VendorSupply> VendorSupplies { get; set; }
    }
}
