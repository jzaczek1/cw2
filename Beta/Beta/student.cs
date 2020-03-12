using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Beta
{
    public class student
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
        public Studies studies { get; set; }


        [XmlAttribute]
        public string indexNumber { get; set; }


        public student()
        {

        }
        public student(string line)
        {
            var split = line.Split(",");
            if (split.Length < 9) throw new NotEnoughFieldsException("Za mało pól exception");

            foreach (var s in split)
            {
                if (s.Trim() == "")
                {
                    throw new EmptyFieldsException("Puste pola Exception");
                }
            }

            fname = split[0];
            lname = split[1];
            studies = new Studies
            {
                name = split[2],
                mode = split[3]
            };
            indexNumber = $"s{IntegerType.FromObject(split[4])}";
            birthdate = split[5];
            email = split[6];
            mothersName = split[7];
            fathersName = split[8];
        }

        public override string ToString()
        {
            return
                $"{fname} {lname} {studies.name} {studies.mode} {indexNumber} {birthdate} {email} {mothersName} {fathersName}";
        }
    }

    public class Studies
    {
        public string name { get; set; }
        public string mode { get; set; }
    }

    public class StudentComparer : IEqualityComparer<student>
    {
        public bool Equals(student x, student y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals(
                    $"{x.fname} {x.lname} {x.indexNumber}",
                    $"{y.fname} {y.lname} {y.indexNumber}");
        }

        public int GetHashCode(student o)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{o.fname} {o.lname} {o.indexNumber}");
        }
    }
}