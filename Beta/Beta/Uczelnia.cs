using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Beta
{
    [XmlRootAttribute("uczelnia")]
    public class Uczelnia
    {
        [XmlAttribute]
        public string createdAt { get; set; }

        [XmlAttribute]
        public string author { get; set; }
        public HashSet<student> studenci { get; set; }

        public Uczelnia()
        {
            createdAt = DateTime.Now.ToShortDateString();
        }
    }
}