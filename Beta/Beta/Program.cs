using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Beta
{
    class Program
    {
        static void Main(string[] args)
        {
            var dane = args.Length > 0 ? args[0] : "data.csv";
            var zapis = args.Length > 1 ? args[1] : "result.xml";
            var format = args.Length > 2 ? args[2] : "xml";
               
            var uczelnia = new Uczelnia
            {
                studenci = read(dane),
                author = "Jan Żaczek"
            };

            if (format == "xml")
            {
                var xmlSerializer = new XmlSerializer(typeof(Uczelnia));
                xmlSerializer.Serialize(File.Create(zapis), uczelnia);
            }
            else if (format == "json")
            {
                var zmienna = JsonConvert.SerializeObject(uczelnia);
                var zapisz = new StreamWriter(zapis);
                zapisz.WriteLine(zmienna);
                zapisz.Close();
            }
        }

        public static HashSet<student> read(string sciezka)
        {
            var bledyzapis = new Bledy();
            var odczyt = File.ReadLines(sciezka);
            var comparer = new MyOwnComparator();
            var studenci = new HashSet<student>(comparer);
            var counter = 0;    //ta zmienna pokaze nam ktore wiersze z dane.csv odrzucilismy jako duplikat
            foreach (var line in odczyt)
            {
                counter++;
                try
                {
                    var studentos = new student(line);
                    if(!studenci.Add(studentos))
                        System.Console.WriteLine("Student z wiersza: " + counter + " się powtarza - nie dodałem");
                }
                catch (NotEnoughFieldsException e)  // nie wolno dac catch(Exception e) - poniewaz wtedy nie rozroznimy bledu
                {                                   // trzeba dac 2 wlasne zeby rozroznic te bledy
                    Bledy.file.WriteLine(line + ": Za mało pól");
                }
                catch (EmptyFieldsException e)
                {
                    Bledy.file.WriteLine(line + ": Puste pola");
                }
            }

            Bledy.file.Flush();
            Bledy.file.Close();
            return studenci;    // zwracamy HashSet
        }
    }
}