using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product() { } 
        public Product(string _sku, string? _name = null, decimal? _price = null, int? _stock = 0) {
            Sku = _sku;
            Name = _name;
            CurrentUnitPrice = _price;
            StockQuantity = _stock;
            IsActive = true;
        }
        public string Sku { get; set; }
        public string? InternalCode { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? CurrentUnitPrice { get; set; }
        public int? StockQuantity { get; set; }
        public bool IsActive { get; set; } 
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
