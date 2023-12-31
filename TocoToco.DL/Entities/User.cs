﻿using System;
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
    /// lớp người dùng
    /// </summary>
    /// created by: ntvu (20/08/2023)
    public class User : BaseEntity
    {
        [EmailAddress]
        public string Email { get; set; }                               // email

        public string PasswordHash { get; set; }                        // mật khẩu

        [StringLength(50)]
        public string Name { get; set; }                                // tên

        [StringLength(500)]
        public string Address { get; set; }                             // địa chỉ

        [StringLength(20)]
        public string Phone { get; set; }                               // số điện thoại

        public string RefreshToken { get; set; } = string.Empty;        // refresh token
        public DateTime RfExpireTime { get; set; }                      // thời gian hết hạn

        [Column(TypeName = "uniqueidentifier")]
        public Guid RoleId { get; set; }                                // id quyền
        public Role Role { get; set; } = null!;

        public List<Order> Order { get; set; } = new List<Order>();     // order của người dùng
    }
}
