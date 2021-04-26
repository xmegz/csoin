using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Csoin.Server.Api
{
    public class UserModel : AModel
    {
        public UserModel() { }

        [Required]
        [XmlAttribute]
        public string Name { get; set; }

        [Required]
        [XmlAttribute]
        public string Password { get; set; }

        [Required]
        [XmlAttribute]
        public string UserGroup { get; set; }

        [XmlAttribute]
        public string Note { get; set; }

        public override string GetKey() { return this.Name; }
    }
}
