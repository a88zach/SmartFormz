using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFormz.Business.Exceptions
{
    public class DatabaseNotInitializedException : Exception
    {
        public DatabaseNotInitializedException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
