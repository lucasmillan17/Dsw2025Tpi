using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Dtos
{
    public record ProductModel
    {
        public record Request(
            [Required] string Sku,
            string InternalCode,
            [Required] string Nombre,
            string Description,
            [Range(0.01, double.MaxValue)] decimal CurrentUnitPrice,
            [Range(0, int.MaxValue)] int StockQuantity
            );
        public record Response(
            string Sku,
            string Nombre,
            string Description,
            decimal CurrentUnitPrice,
            int StockQuantity
            );
    }
}
