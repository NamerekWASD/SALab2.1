using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ExistingItemInCollectionException : Exception
    {
        public ExistingItemInCollectionException(string message) 
            : base(message) { }
    }
}
