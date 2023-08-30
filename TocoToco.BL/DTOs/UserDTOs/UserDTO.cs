using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocoToco.BL.DTOs.RoleDTOs;
using TocoToco.DL.Entities;

namespace TocoToco.BL.DTOs.UserDTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }            // id người dùng

        public string Email { get; set; }       // email

        public string Name { get; set; }        // tên

        public string Address { get; set; }     // địa chỉ

        public string Phone { get; set; }       // số điện thoại

        public string PasswordHash { get; set; }    // mật khẩu đã được hash
        public Role Role { get; set; }    // quyền
    }
}
