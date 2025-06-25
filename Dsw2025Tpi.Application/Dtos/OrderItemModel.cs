using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Dtos
{
    public record OrderItemModel
    {
        public record Request(
            [Required]string ProductCode,
            [Required][Range(0,int.MaxValue)] int Quantity
            );

        public record Response(
            string Name,
            string Description,
            decimal CurrentUnitPrice
            );
    }
}
