using System.Xml.Serialization;

namespace Csoin.Server.Persistence.Models
{
    public struct UserGroupRecord
    {
        public UserGroupRecord(string name, string note)
        {
            this.Name = name;
            this.Note = note;
        }

        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("note")]
        public string Note { get; set; }
    }
}
