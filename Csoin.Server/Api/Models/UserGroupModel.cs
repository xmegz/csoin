using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Csoin.Server.Api
{
    public class UserGroupModel : AModel
    {
        public UserGroupModel() { }

        public UserGroupModel(string name, string note)
        {
            this.Name = name;
            this.Note = note;
        }

        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Name { get; set; }

        [StringLength(maximumLength: 250)]
        public string Note { get; set; }

        public override string GetKey() { return this.Name; }
    }
}
