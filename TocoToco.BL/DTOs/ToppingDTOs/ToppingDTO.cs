using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.BL.DTOs.ToppingDTOs
{
    public class ToppingDTO
    {
        public Guid Id { get; set; }                // id
        public string Name { get; set; }            // tên
        public int Price { get; set; }              // giá
    }
}
