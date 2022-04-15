using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALab2._1.Exceptions
{
    internal class ExistenceEmailException : Exception
    {
        public ExistenceEmailException(string message) : base(message) { }
    }
}
