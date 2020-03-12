using System;
using System.Collections.Generic;
using System.Text;

namespace Beta
{
    class NotEnoughFieldsException : Exception
    {
        public NotEnoughFieldsException(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
