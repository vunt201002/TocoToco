using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.Common.Exceptions
{
    public class BaseException : Exception
    {
        public string? ErrorMsg { get; set; }
        public IDictionary? ErrorData { get; set; }
        public object? Result { get; set; }
    }
}
