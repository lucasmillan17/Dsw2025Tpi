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
        public Order(Customer _customer, string _shippingAddress, string _billingAdress, List<OrderItem> _orderItems) { 
            Customer = _customer;
            ShippingAddress = _shippingAddress;
            BillingAddress = _billingAdress;

            foreach (var item in _orderItems) { 
                OrderItems.Add(item);    
            }
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

    }
}
