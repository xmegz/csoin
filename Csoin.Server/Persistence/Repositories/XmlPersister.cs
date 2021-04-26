using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Csoin.Server.Persistence.Repositories
{
    public class XmlPersister
    {
        public static string SubDir = "Models";
        public static string FileExtension = ".xml";
    }

    public class XmlPersister<T> : XmlPersister where T : struct
    {
        public string FileName { get; private set; }
        public string DirName { get; private set; }
        public XmlSerializer XmlSerializer { get; private set; }

        public XmlPersister()
        {
            this.DirName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            this.DirName = Path.Combine(this.DirName, SubDir);

            this.FileName = Path.Combine(this.DirName, typeof(T).Name + FileExtension);
            this.XmlSerializer = new XmlSerializer(typeof(List<T>));
        }

        /// <summary>
        /// Load list
        /// </summary>
        public List<T> Load()
        {
            List<T> outList = new List<T>();

            Directory.CreateDirectory(this.DirName);

            if (File.Exists(this.FileName))
            {
                using (Stream st = File.OpenRead(this.FileName))
                {
                    outList = (List<T>)this.XmlSerializer.Deserialize(st);
                    st.Close();
                }
            }

            return outList;
        }

        /// <summary>
        /// Save list
        /// </summary>
        public void Save(IList<T> inList)
        {
            Directory.CreateDirectory(this.DirName);

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8
            };

            using (XmlWriter writer = XmlTextWriter.Create(this.FileName, settings))
            {
                this.XmlSerializer.Serialize(writer, inList);
            }
        }
    }
}
