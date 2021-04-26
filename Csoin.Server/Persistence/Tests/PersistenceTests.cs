using Csoin.Server.Persistence.Models;
using Csoin.Server.Persistence.Repositories;
using System.Collections.Generic;
using System.IO;

namespace Csoin.Server.Persistence.Tests
{
    public class PersistenceTests
    {
        public void TestMethod1()
        {
            XmlPersister.SubDir = "TestModels";
            {
                List<UserRecord> l1 = Repository<UserRecord>.Get();

                if (File.Exists(new XmlPersister<UserRecord>().FileName))
                {
                    File.Delete(new XmlPersister<UserRecord>().FileName);
                }

                l1.Add(new UserRecord(name: null, password: "password1", userGroup: "userGroup1", note: "note1"));
                l1.Add(new UserRecord(name: "name2", password: null, userGroup: "userGroup2", note: "note2"));
                l1.Add(new UserRecord(name: "name3", password: "password3", userGroup: null, note: "note3"));
                l1.Add(new UserRecord(name: "name4", password: "password4", userGroup: "userGroup4", note: null));
                l1.Add(new UserRecord(name: "name5", password: "password5", userGroup: "userGroup5", note: "note5"));
                l1.Add(new UserRecord(name: "name6", password: "password6", userGroup: "userGroup6", note: "note6"));

                Repository<UserRecord>.SaveAndSet(l1);

                Repository<UserRecord>.LoadAndSet();

                UserRecord u = l1[0];
                u.Name = "name6";

                l1.Remove(l1[0]);
                l1.Add(u);
                
                var l2 = Repository<UserRecord>.Get();

                l2.AddRange(l1);

                Repository<UserRecord>.SaveAndSet(l2);

            }
        }
    }
}
