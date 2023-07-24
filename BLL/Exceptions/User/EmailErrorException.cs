using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions.User
{
    public class EmailErrorException : Exception
    {
        public EmailErrorException(string? message) : base(message)
        { }
    }
}
