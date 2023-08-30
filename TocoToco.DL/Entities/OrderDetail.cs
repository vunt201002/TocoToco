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
    public class OrderDetail : BaseEntity
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid OrderId { get; set; }               // id đơn
        public Order Order { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid ProductId { get; set; }             // id sản phẩm đặt
        public Product Product { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid TypeOrderId { get; set; }           // id loại order
        public TypeOrder TypeOrder { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid SizeOrderId { get; set; }           // id size
        public SizeOrder SizeOrder { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid SugarId { get; set; }               // id đường
        public Sugar Sugar { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid IceId { get; set; }                 // id đá
        public Ice Ice { get; set; }

        public int Count { get; set; }                  // số sản phẩm
        public int TotalPrice { get; set; }             // tổng đơn

        public List<ToppingOrder> ToppingOrder { get; set; } = new List<ToppingOrder>();
    }
}
