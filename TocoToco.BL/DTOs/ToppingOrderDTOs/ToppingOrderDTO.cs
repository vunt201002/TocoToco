using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.BL.DTOs.ToppingOrderDTOs
{
    public class ToppingOrderDTO
    {
        public Guid Id { get; set; }                            // id
        public Guid ToppingId { get; set; }                     // id topping
        public Guid OrderDetailId { get; set; }                 // id order detail
    }
}
