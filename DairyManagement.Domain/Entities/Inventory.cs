using System;
using System.Collections.Generic;

namespace DairyManagement.Infrastructure
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
