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
            string text = "Podan ścieżka jest niepoprawna";

            try
            {
                var lines = File.ReadLines(path);
                foreach (var line in lines)
                {
                    Console.WriteLine(lines);
                }
            }catch(ArgumentException ex)
            {
                File.WriteAllText(pathLog, text);
            }
            catch(FileNotFoundException ex)
            {
                File.WriteAllText(pathLog, "Plik nazwa nie istnieje");
            }

            //Newtonsoft.JSON   - to jakas biblioteka dodatkowa
            //JsonConvert.SerializableObject() - nazwa metody bodajze
            

            var parsedDate = DateTime.Parse("2020-03-10");
            Console.WriteLine(parsedDate);

            var today = DateTime.Today;
            Console.WriteLine(today.ToShortDateString());

            //metoda hasset.add() zwraca rowniez bool wiec mozna to przy kopiach
            //wykorzystac

            Console.WriteLine("Tekst");
        }
    }
}
