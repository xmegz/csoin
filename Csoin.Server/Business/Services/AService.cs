using Csoin.Server.Api;
using Csoin.Server.Interfaces;
using Csoin.Server.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Csoin.Server.Services
{
    public class AService<T> : IAService<T> where T : AModel
    {
        public AService()
        {
            this._fileName = this.GetFileName();
            this._serializer = new XmlSerializer(typeof(List<T>));
            this.LoadFromFile();
        }

        private ConcurrentDictionary<string, T> _TDictionary = new ConcurrentDictionary<string, T>();

        protected static object _lock = new object();
       
        private string GetFileName()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            string dir = Path.GetDirectoryName(assembly.Location);
            dir = Path.Combine(dir, "Models");

            return Path.Combine(dir, typeof(T).Name + ".xml");
        }

        private readonly string _fileName;
        private readonly XmlSerializer _serializer;

        public void LoadFromFile()
        {
            string fileName = this._fileName;

            Directory.CreateDirectory(Path.GetDirectoryName(fileName));

            if (File.Exists(fileName))
            {
                object o = null;

                using (Stream st = File.OpenRead(fileName))
                {
                    o = (object)this._serializer.Deserialize(st);
                    st.Close();
                }

                List<T> list = (List<T>)o;

                ConcurrentDictionary<string, T> dict = new ConcurrentDictionary<string, T>(list.ToDictionary(a => a.GetKey()));

                this._TDictionary = dict;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveToFile()
        {
            string fileName = this._fileName;

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8
            };


            Directory.CreateDirectory(Path.GetDirectoryName(fileName));

            using (XmlWriter writer = XmlTextWriter.Create(fileName, settings))
            {

                var modelDictionary = this._TDictionary;
                List<T> list = new List<T>();

                foreach (var i in modelDictionary)
                {
                    list.Add(i.Value);
                }

                this._serializer.Serialize(writer, list);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T Get(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var modelDictionary = this._TDictionary;

            if (!modelDictionary.TryGetValue(key, out T item))
                throw new ArgumentException(typeof(T) + " not exist", nameof(key));

            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetAll()
        {
            var modelDictionary = this._TDictionary;

            List<T> list = new List<T>();

            foreach (var i in modelDictionary)
            {
                list.Add(i.Value);
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual T Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (item.GetKey() == null)
                throw new ArgumentNullException("key");

            var modelDictionary = this._TDictionary;

            if (!modelDictionary.TryAdd(item.GetKey(), item))
                throw new ArgumentException("Exist", nameof(item));

            this.SaveToFile();

            return null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual T Update(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (item.GetKey() == null)
                throw new ArgumentNullException("key");

            var modelDictionary = this._TDictionary;

            if (!modelDictionary.TryGetValue(item.GetKey(), out T oldItem))
                throw new ArgumentException("Not exist", nameof(item));

            if (!modelDictionary.TryUpdate(item.GetKey(), item, oldItem))
                throw new ArgumentException("Failed", nameof(item));

            this.SaveToFile();

            return null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public virtual T Delete(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            this.SaveToFile();

            return null;

        }
    }
}
