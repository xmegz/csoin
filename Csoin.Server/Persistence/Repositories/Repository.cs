using System.Collections.Generic;

namespace Csoin.Server.Persistence.Repositories
{
    public static class Repository<T> where T : struct
    {
        private static List<T> _recordList = new List<T>();
        private static XmlPersister<T> _presister = new XmlPersister<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<T> Get()
        {
            List<T> outList = new List<T>();

            foreach (T i in _recordList)
            {
                T rec = i;
                outList.Add(rec);
            }

            return outList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inList"></param>
        public static void Set(List<T> inList)
        {
            List<T> outList = new List<T>();
            
            foreach (T i in inList)
            {
                T rec = i;
                outList.Add(i);
            }

            _recordList = outList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inList"></param>
        public static void SaveAndSet(List<T> inList)
        {
            _presister.Save(inList);
            Set(inList);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void LoadAndSet()
        {
            List<T> inList = _presister.Load();
            Set(inList);
        }
    }
}
