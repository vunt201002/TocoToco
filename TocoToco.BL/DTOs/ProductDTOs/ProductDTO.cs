using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TocoToco.DL.Entities;

namespace TocoToco.BL.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }                // id
        public string Name { get; set; }            // tên

        public string Image { get; set; }           // link ảnh
        
        public string Description { get; set; }     // mô tả
        public int Price { get; set; }              // giá
        public int Discount { get; set; }           // giảm giá

        public Guid CategoryId { get; set; }        // id loại sản phẩm
        public Category Category { get; set; }
    }
}
