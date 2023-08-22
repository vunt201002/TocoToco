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
    public class OrderDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();          // id
        public string Name { get; set; }                        // tên người đặt
        public string Address { get; set; }                     // địa chỉ đặt

        public string Phone { get; set; }                       // số điện thoại

        public string Note { get; set; }                        // ghi chú đơn hàng
        public DateTime OrderAt { get; set; } = DateTime.Now;   // ngày đặt
        public string Status { get; set; }                      // trạng thái
        public string Pay { get; set; }                         // thanh toán
        public int TotalPrice { get; set; }                     // tổng đơn

        public Guid UserId { get; set; }                        // id người đặt
    }
}
