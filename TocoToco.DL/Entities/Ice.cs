using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.DL.Base;

namespace TocoToco.DL.Entities
{
    public class Ice : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }            // tên

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
