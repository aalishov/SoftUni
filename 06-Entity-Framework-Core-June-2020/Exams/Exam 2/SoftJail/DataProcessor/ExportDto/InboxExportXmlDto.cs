using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class InboxExportXmlDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public EcreptedMessage[] EncryptedMessages { get; set; }


    }

    [XmlType("Message")]
    public class EcreptedMessage
    {
        public string Description { get; set; }

        [XmlIgnore]
        public string ReverseS { get; set; }


        private string Reverse(string r)
        {
            var c = r.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }
    }
}
