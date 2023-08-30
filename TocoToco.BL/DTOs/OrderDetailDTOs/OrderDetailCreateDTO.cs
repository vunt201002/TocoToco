using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TocoToco.BL.DTOs.OrderDetailDTOs
{
    public class OrderDetailCreateDTO
    {
        public Guid OrderId { get; set; }               // id đơn

        [Column(TypeName = "uniqueidentifier")]
        public Guid ProductId { get; set; }             // id sản phẩm đặt

        [Column(TypeName = "uniqueidentifier")]
        public Guid TypeOrderId { get; set; }           // id loại order

        [Column(TypeName = "uniqueidentifier")]
        public Guid SizeOrderId { get; set; }           // id size

        [Column(TypeName = "uniqueidentifier")]
        public Guid SugarId { get; set; }               // id đường

        [Column(TypeName = "uniqueidentifier")]
        public Guid IceId { get; set; }                 // id đá

        public int Count { get; set; }                  // số sản phẩm
        public int TotalPrice { get; set; }             // tổng đơn
    }
}
