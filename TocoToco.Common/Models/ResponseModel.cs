using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.Common.Models
{
    public class ResponseModel
    {
        public string? DevMsg { get; set; }
        public string? UserMsg { get; set; }
        public object? Data { get; set; }
        public object? Error { get; set; }
    }
}
