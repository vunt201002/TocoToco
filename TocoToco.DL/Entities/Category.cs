using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.DL.Base;

namespace TocoToco.DL.Entities
{
    /// <summary>
    /// lớp loại sản phẩm
    /// </summary>
    /// created by: ntvu (21/08/2023)
    public class Category : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }                                    // tên
        public List<Product> Products { get; set; } = new List<Product>();  // danh sách sản phẩm
    }
}
