using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocoToco.Common.Enumeration
{
    public class Enum
    {
        public enum ReturnCode
        {
            Success = 200,
            Created = 201,
            NoContent = 204,
            BadRequest = 400,
            ServerError = 500,
        }
    }
}
