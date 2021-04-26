using System.Xml.Serialization;

namespace Csoin.Server.Persistence.Models
{
    public struct EventTypeRecord
    {
        public EventTypeRecord(string name, int amount, string note)
        {
            this.Name = name;
            this.Amount = amount;
            this.Note = note;
        }

        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("amount")]
        public int Amount { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }
    }
}
