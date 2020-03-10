using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CW2
{
    class Program
    { 
    

        public static void Main(String[] args)
        {
            var path = @"C:\Users\s18593\Desktop";
            var pathLog = @"C:\Users\s18593\Desktop";
            string[] text2 = { "Podana scieżka", " jest niepoprawna" };
            string text2 = "Podana sciexka";

            try
            {
                var lines = File.ReadLines(path);
                foreach (var line in lines)
                {
                    Console.WriteLine(lines);
                }
            }catch(ArgumentException ex)
            {
                File.WriteAllLines(pathLog, text2);
            }
            catch(FileNotFoundException ex)
            {

            }
            

            var parsedDate = DateTime.Parse("2020-03-10");
            Console.WriteLine(parsedDate);

            var today = DateTime.Today;
            Console.WriteLine(today.ToShortDateString());


        }
    }
}
