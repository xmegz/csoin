using System;
using System.Xml.Serialization;

namespace Csoin.Server.Persistance.Models
{
    public struct EventRecord
    {
        public EventRecord(string name, DateTime created, string eventType, string user, string userGroup, int amount, int balance, string note)
        {
            this.Name = name;
            this.Created = created;
            this.EventType = eventType;
            this.User = user;
            this.UserGroup = userGroup;
            this.Amount = amount;
            this.Balance = balance;
            this.Note = note;
        }

        [XmlAttribute("name")]
        public string Name { get; set; }
                
        [XmlAttribute("created")]
        public DateTime Created { get; set; }
        
        [XmlAttribute("eventtype")]
        public string EventType { get; set; }
        
        [XmlAttribute("user")]
        public string User { get; set; }

        [XmlAttribute("usergroup")]
        public string UserGroup { get; set; }

        [XmlAttribute("amount")]
        public int Amount { get; set; }
                
        [XmlAttribute("blance")]
        public int Balance { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }


    }
}
