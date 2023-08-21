using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.BL.DTOs.CategoryDTOs
{
    public class CategoryCreateDTO
    {
        [StringLength(50)]
        public string Name { get; set; }            // tên
    }
}
