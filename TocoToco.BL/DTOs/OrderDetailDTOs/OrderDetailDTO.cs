using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TocoToco.DL.Entities;

namespace TocoToco.BL.DTOs.OrderDetailDTOs
{
    public class OrderDetailDTO
    {
        public Guid Id { get; set; }                    // id
        public Guid OrderId { get; set; }               // id đơn

        public Guid ProductId { get; set; }             // id sản phẩm đặt

        public Guid TypeOrderId { get; set; }           // id loại order

        public Guid SizeOrderId { get; set; }           // id size

        public Guid SugarId { get; set; }               // id đường

        public Guid IceId { get; set; }                 // id đá

        public int Count { get; set; }                  // số sản phẩm
        public int TotalPrice { get; set; }             // tổng đơn
    }
}
