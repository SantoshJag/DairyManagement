using System;
using System.Collections.Generic;

namespace DairyManagement.Infrastructure
{
    public partial class VendorSupply
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Vendor Vendor { get; set; } = null!;
    }
}
