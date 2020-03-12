using System;
using System.Collections.Generic;
using System.Text;

namespace Beta
{
    class EmptyFieldsException : Exception
    {
        public EmptyFieldsException(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
