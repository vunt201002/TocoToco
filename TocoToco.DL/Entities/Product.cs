using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TocoToco.DL.Base;

namespace TocoToco.DL.Entities
{
    /// <summary>
    /// lớp sản phẩm
    /// </summary>
    /// created by: ntvu (21/08/2023)
    public class Product : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }            // tên

        public string Image { get; set; }           // link ảnh

        [StringLength(500)]
        public string Description { get; set; }     // mô tả
        public int Price { get; set; }              // giá
        public int Discount { get; set; }           // giảm giá

        [Column(TypeName = "uniqueidentifier")]
        public Guid CategoryId { get; set; }        // id loại sản phẩm
        public Category Category { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
