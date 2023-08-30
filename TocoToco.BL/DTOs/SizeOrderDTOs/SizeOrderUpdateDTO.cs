using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.BL.DTOs.SizeOrderDTOs
{
    public class SizeOrderUpdateDTO
    {
        public Guid Id { get; set; }                    // id
        public string Name { get; set; }                // tên size
        public int PriceAdd { get; set; }               // giá cộng thêm
    }
}
