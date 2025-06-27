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
            [Required(ErrorMessage ="El codigo de producto es obligatorio.")]
            Guid ProductCode,

            [Required(ErrorMessage = "La cantidad es obligatoria.")]
            [Range(0,int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa.")] 
            int Quantity
            );

        public record Response(
            string? Name,
            string? Description,
            int? Quantity,
            decimal? Subtotal
            );
    }
}
