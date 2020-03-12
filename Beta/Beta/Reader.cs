using System;
using System.Collections.Generic;
using System.IO;

namespace Beta
{
    public class CSVReader
    {
        public static HashSet<student> read(string path)
        {
            var logger = new Logger();

            var lines = File.ReadLines(path);
            var comparer = new StudentComparer();
            var res = new HashSet<student>(comparer);
            var sum = 0;
            foreach (var line in lines)
            {
                sum++;

                try
                {
                    var st = new student(line);
                    res.Add(st);
                }
                catch (NotEnoughFieldsException e)
                {
                    logger.log(line + "  - Not enough fields");
                }
                catch (EmptyFieldsException e)
                {
                    logger.log(line + "  - Empty fields");
                }
            }

            logger.Dispose();
            return res;
        }
    }
}