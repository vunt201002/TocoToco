using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TocoToco.BL.DTOs.ProductDTOs
{
    public class ProductCreateDTO
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
    }
}
