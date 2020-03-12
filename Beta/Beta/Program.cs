using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Beta
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args.Length > 0 ? args[0] : "data.csv";
            var savePath = args.Length > 1 ? args[1] : "result.xml";
            var format = args.Length > 2 ? args[2] : "xml";
               

            var uczelnia = new Uczelnia
            {
                studenci = CSVReader.read(path),
                author = "Jan Żaczek"
            };

            if (format == "xml")
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Uczelnia));
                xmlSerializer.Serialize(File.Create(savePath), uczelnia);
            }
            else if (format == "json")
            {
                string output = JsonConvert.SerializeObject(uczelnia);
                var writer = new System.IO.StreamWriter(savePath, false);
                writer.WriteLine(output);
                writer.Close();
            }
        }
    }
}