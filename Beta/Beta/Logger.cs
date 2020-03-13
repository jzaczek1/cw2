using System;

namespace Beta
{
    public class Logger : IDisposable
    {
        private System.IO.StreamWriter file;

        public Logger()
        {
            file = new System.IO.StreamWriter("log.txt");
            file.WriteLine(DateTime.Now);
        }

        public void log(string line)
        {
            file.WriteLine(line);
        }

        public void Dispose()
        {
            file.Flush();
            file.Close();
        }
    }
}