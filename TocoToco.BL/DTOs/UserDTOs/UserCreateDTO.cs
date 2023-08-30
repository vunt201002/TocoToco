using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TocoToco.BL.DTOs.UserDTOs
{
    public class UserCreateDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }               // email

        [Required]
        public string Name { get; set; }                // tên

        [Required]
        public string Address { get; set; }             // địa chỉ

        [Required]
        public string Phone { get; set; }               // số điện thoại

        [Required]
        public string Password { get; set; }            // mật khẩu

        [Column(TypeName = "uniqueidentifier")]
        public Guid RoleId { get; set; }                // id quyền
    }
}
