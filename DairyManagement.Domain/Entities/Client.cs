using System;
using System.Collections.Generic;

namespace DairyManagement.Infrastructure
{
    public partial class Client
    {
        public Client()
        {
            ClientOrders = new HashSet<ClientOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<ClientOrder> ClientOrders { get; set; }
    }
}
