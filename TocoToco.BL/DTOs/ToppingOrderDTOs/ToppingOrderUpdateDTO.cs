using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TocoToco.BL.DTOs.ToppingOrderDTOs
{
    public class ToppingOrderUpdateDTO
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }                            // id

        [Column(TypeName = "uniqueidentifier")]
        public Guid ToppingId { get; set; }                     // id topping

        [Column(TypeName = "uniqueidentifier")]
        public Guid OrderDetailId { get; set; }                 // id order detail
    }
}
