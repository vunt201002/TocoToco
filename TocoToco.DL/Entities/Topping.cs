using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.DL.Base;

namespace TocoToco.DL.Entities
{
    public class Topping : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }        // tên topping
        public int Price { get; set; }          // giá topping
        public List<ToppingOrder> ToppingOrder { get; set; } = new List<ToppingOrder>();
    }
}
