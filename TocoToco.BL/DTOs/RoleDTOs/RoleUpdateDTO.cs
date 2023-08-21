using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TocoToco.BL.DTOs.RoleDTOs
{
    public class RoleUpdateDTO
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }            // id

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }       // tên
    }
}
