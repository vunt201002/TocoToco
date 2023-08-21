using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.DL.Entities;

namespace TocoToco.BL.DTOs.RoleDTOs
{
    public class RoleDTO
    {
        public Guid Id { get; set; }            // id
        public string? Name { get; set; }       // tên
        public List<User> Users { get; set; }   // danh sách người dùng
    }
}
