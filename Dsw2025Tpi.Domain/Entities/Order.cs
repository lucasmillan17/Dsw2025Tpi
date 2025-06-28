using Dsw2025Tpi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Order : EntityBase
    {
        public Order() { }
        public Order(Customer customer, string shippingAddress, string billingAdress, List<OrderItem> orderItems) { 
            Customer = customer;
            CustomerId = customer.Id;
            ShippingAddress = shippingAddress;
            BillingAddress = billingAdress;

            foreach (var item in orderItems) { 
                OrderItems.Add(item);    
            }
            Status = OrderStatus.PENDING;
            Date = DateTime.Now;
        }
        public DateTime Date { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string? Notes { get; set; }
        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        //Sumamos los subtotales de los items para obtener el total de la orden
        public decimal? TotalAmount => OrderItems.Sum(item => item.Subtotal);
        public OrderStatus Status { get; set; }
    }
}
