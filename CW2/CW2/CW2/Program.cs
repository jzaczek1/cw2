﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CW2
{
    class Program
    { 
        static void Main(string[] args)
        {
            string path = @"dane.csv";
            Console.WriteLine("Hello World");

            //Wczytywanie 
            var fi = new FileInfo(path);
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] kolumny = line.Split(',');
                    Console.WriteLine(line);
                }
            }
            //stream.Dispose();

            //XML
            var list = new List<Student>();
            var st = new Student
            {
                Imie="Jan",
                Nazwisko="Kowalski",
                Email="kowalski@wp.pl"
            };
            list.Add(st);

            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, list);
            serializer.Serialize(writer, list);

        }
    }
}
// rozw tego zadania w branchu dev
