using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TocoToco.BL.DTOs.OrderDTOs
{
    public class OrderUpdateDTO
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; } = Guid.NewGuid();          // id

        [StringLength(100)]
        public string Name { get; set; }                        // tên người đặt

        [StringLength(500)]
        public string Address { get; set; }                     // địa chỉ đặt

        [StringLength(20)]
        public string Phone { get; set; }                       // số điện thoại

        [StringLength(1000)]
        public string Note { get; set; }                        // ghi chú đơn hàng
        public DateTime OrderAt { get; set; } = DateTime.Now;   // ngày đặt
        public string Status { get; set; }                      // trạng thái
        public string Pay { get; set; }                         // thanh toán
        public int TotalPrice { get; set; }                     // tổng đơn

        [Column(TypeName = "uniqueidentifier")]
        public Guid UserId { get; set; }                        // id người đặt
    }
}
