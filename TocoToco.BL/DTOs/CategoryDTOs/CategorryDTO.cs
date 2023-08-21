using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.DL.Entities;

namespace TocoToco.BL.DTOs.CategoryDTOs
{
    public class CategorryDTO
    {
        public Guid Id { get; set; }                    // id
        public string Name { get; set; }                // tên
        public List<Product> Products { get; set; }     // danh sách sản phẩm
    }
}
