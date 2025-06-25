using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Order : EntityBase
    {
        public DateTime Date { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingCity { get; set; }
        public string? Notes { get; set; }
        public decimal TotalAmount { get; private set; }
        public OrderItem OrderItems { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
