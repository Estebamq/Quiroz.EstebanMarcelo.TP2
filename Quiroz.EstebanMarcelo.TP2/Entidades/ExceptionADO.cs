using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExceptionADO : Exception
    {
        public ExceptionADO(string message) : base(message)
        {


        }
    }
}
