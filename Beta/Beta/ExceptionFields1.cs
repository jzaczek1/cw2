using System;

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
