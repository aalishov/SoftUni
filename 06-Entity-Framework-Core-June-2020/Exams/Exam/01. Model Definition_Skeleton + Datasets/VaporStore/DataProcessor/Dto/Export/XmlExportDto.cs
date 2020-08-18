using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class XmlExportDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public Purchase[] Purchases { get; set; }
    }

    [XmlType("Purchase")]
    public class PurchaseXml
    {
        public string Card { get; set; }

        public string Cvc { get; set; }

        public string Date { get; set; }

        [XmlElement("Game")]
        public GameXml MyProperty { get; set; }
    }

    public class GameXml
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Price")]
        public string Price { get; set; }
    }

}
