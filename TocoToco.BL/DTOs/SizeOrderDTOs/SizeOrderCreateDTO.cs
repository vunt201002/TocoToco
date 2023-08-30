using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.BL.DTOs.SizeOrderDTOs
{
    public class SizeOrderCreateDTO
    {
        [StringLength(100)]
        public string Name { get; set; }                // tên size
        public int PriceAdd { get; set; }               // giá cộng thêm
    }
}
