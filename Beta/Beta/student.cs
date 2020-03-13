using System.Xml.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Beta
{
    public class student
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
        public Studia studia { get; set; }


        [XmlAttribute]
        public string indexNumber { get; set; }

        public student()    // musi być konstruktor bez parametrow inaczej błąd wyrzuca przy serialzacji np. xml
        {

        }

        public student(string line)
        {
            var split = line.Split(",");
            if (split.Length < 9) throw new NotEnoughFieldsException("Za mało pól exception");

            foreach (var s in split)
            {
                if (s.Trim() == string.Empty)
                {
                    throw new EmptyFieldsException("Puste pola Exception");
                }
            }

            firstname = split[0];
            lastname = split[1];
            studia = new Studia
            {
                nazwa = split[2],
                tryb = split[3]
            };
            indexNumber = $"s{IntegerType.FromObject(split[4])}";
            birthday = split[5];
            email = split[6];
            mothersName = split[7];
            fathersName = split[8];
        }

        public override string ToString()
        {
            return
                $"{firstname} {lastname} {studia.nazwa} {studia.tryb} {indexNumber} {birthday} {email} {mothersName} {fathersName}";
        }
    }

    public class Studia
    {
        public string nazwa { get; set; }
        public string tryb { get; set; }
    }
}