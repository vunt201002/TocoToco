using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.BL.DTOs.ToppingDTOs
{
    public class ToppingCreateDTO
    {
        [StringLength(100)]
        public string Name { get; set; }        // tên topping
        public int Price { get; set; }          // giá topping
    }
}
