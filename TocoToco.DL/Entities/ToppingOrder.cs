using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TocoToco.DL.Base;

namespace TocoToco.DL.Entities
{
    public class ToppingOrder : BaseEntity
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid ToppingId { get; set; }                     // id topping
        public Topping Topping { get; set; } = null!;

        [Column(TypeName = "uniqueidentifier")]
        public Guid OrderDetailId { get; set; }                 // id order detail
        public OrderDetail OrderDetail { get; set; } = null!;
    }
}
