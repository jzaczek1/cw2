using System;
using System.IO;

namespace Beta
{
    public class Bledy
    {
        public static StreamWriter file;

        public Bledy()
        {
            file = new StreamWriter("log.txt");
            file.WriteLine(DateTime.Now);
        }
    }
}