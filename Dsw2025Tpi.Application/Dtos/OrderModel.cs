using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Dtos
{
    public record OrderModel
    {
        public record Request(
            [Required]Guid CustomerId,
            [Required]string ShippingAdress,
            [Required]string BillingAdress,
            [Required] OrderItemModel[] OrderItems
            );
        public record Response(
            Guid OrderId,
            decimal TotalAmount
            );
    }
}
