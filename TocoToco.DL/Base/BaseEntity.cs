using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.DL.Base
{
    /// <summary>
    /// lớp cơ sở
    /// </summary>
    /// created by: ntvu (20/08/2023)
    public class BaseEntity
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; } = Guid.NewGuid();              // id
        public int Deleted { get; set; } = 0;                       // đã xóa
        public DateTime CreatedAt { get; set; } = DateTime.Now;     // ngày tạo

        [StringLength(maximumLength: 50)]
        public string CreatedBy { get; set; } = "ntvu";             // người tạo
    }
}
