using System;
using System.Collections.Generic;

namespace DairyManagement.Infrastructure
{
    public partial class ClientOrder
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
