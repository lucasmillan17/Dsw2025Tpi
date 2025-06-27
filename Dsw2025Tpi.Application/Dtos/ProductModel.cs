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
            [Required(ErrorMessage = "El SKU es obligatorio.")]
            [MaxLength(50,ErrorMessage = "El SKU no puede superar los 50 caracteres.")]
            string Sku,

            [MaxLength(20, ErrorMessage = "El InternalCode no puede superar los 20 caracteres.")]
            string InternalCode,

            [MaxLength(50, ErrorMessage = "El Nombre no puede superar los 50 caracteres.")]
            string Nombre,

            [MaxLength(60, ErrorMessage = "La descripción no puede superar los 60 caracteres.")]
            string Description,

            [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
            decimal CurrentUnitPrice,

            [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")] 
            int StockQuantity
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
