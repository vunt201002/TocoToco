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
    /// lớp phân quyền
    /// </summary>
    /// created by: ntvu (20/08/2023)
    public class Role : BaseEntity
    {
        [StringLength(50)]
        public string? Name { get; set; }                           // tên       
        public List<User> User { get; set; } = new List<User>();    // danh sách người dùng
    }
}
