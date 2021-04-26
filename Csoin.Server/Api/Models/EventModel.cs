using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Csoin.Server.Api
{
    public class EventModel : AModel
    {
        [Required]
        [XmlAttribute]
        public DateTime Time;

        [Required]
        [XmlAttribute]
        public string EventType { get; set; }

        [Required]
        [XmlAttribute]
        public string User { get; set; }

        [Required]
        [XmlAttribute]
        public string UserGroup { get; set; }

        [Required]
        [XmlAttribute]
        public int Amount { get; set; }

        [Required]
        [XmlAttribute]
        public int Balance { get; set; }

        [XmlAttribute]
        public string Note { get; set; }
        public override string GetKey() { return this.Time.ToBinary().ToString(); }
    }
}
