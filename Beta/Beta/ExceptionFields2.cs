using System;

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
