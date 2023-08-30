﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TocoToco.BL.DTOs.TypeOrderDTOs
{
    public class TypeOrderUpdateDTO
    {
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }                // id

        [StringLength(100)]
        public string Name { get; set; }            // tên
    }
}
