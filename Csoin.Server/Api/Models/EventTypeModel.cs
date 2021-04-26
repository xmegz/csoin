using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Csoin.Server.Api
{
    public class EventTypeModel : AModel
    {
        [Required]
        [XmlAttribute]
        public string Name { get; set; }

        [Required]
        [XmlAttribute]
        public int Amount { get; set; }

        [XmlAttribute]
        public string Note { get; set; }

        public override string GetKey() { return this.Name; }
    }
}
