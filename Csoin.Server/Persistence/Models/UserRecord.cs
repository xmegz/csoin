using System.Xml.Serialization;

namespace Csoin.Server.Persistence.Models
{
    public struct UserRecord
    {
        public UserRecord(string name, string password, string userGroup, string note)
        {
            this.Name = name;
            this.Password = password;
            this.UserGroup = userGroup;
            this.Note = note;
        }

        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("password")]
        public string Password { get; set; }

        [XmlAttribute("usergroup")]
        public string UserGroup { get; set; }

        [XmlAttribute("note")]
        public string Note { get; set; }

    }
}
