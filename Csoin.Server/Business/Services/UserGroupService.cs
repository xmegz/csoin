using Csoin.Server.Api;
using Csoin.Server.Interfaces;
using Csoin.Server.Models;
using Csoin.Server.Persistence.Models;
using Csoin.Server.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csoin.Server.Services
{
    public class UserGroupService : AService<UserGroupModel>, IUserGroupService
    {
        public override UserGroupModel Get(string key)
        {
            List<UserGroupRecord> recordList = new List<UserGroupRecord>();

            lock (_lock)
            {
               recordList = Repository<UserGroupRecord>.Get();
            }

            recordList = recordList.FindAll(a => a.Name == key);

            if (recordList.Count > 0)
            {
                return new UserGroupModel(name: recordList[0].Name, note: recordList[0].Note);
            }
            else
                return null;
        }

        public override List<UserGroupModel> GetAll()
        {
            List<UserGroupRecord> recordList = new List<UserGroupRecord>();

            lock (_lock)
            {
                recordList = Repository<UserGroupRecord>.Get();
            }

            List<UserGroupModel> modelList = new List<UserGroupModel>();

            foreach (var i in recordList)
            {
                modelList.Add(new UserGroupModel(name: i.Name, note: i.Note));
            }

            return modelList;
        }

        public override UserGroupModel Add(UserGroupModel item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            string key = item.GetKey();

            if (key == null)
                throw new ArgumentNullException("item.key");
           
            List<UserGroupRecord> recordList = new List<UserGroupRecord>();

            lock (_lock)
            {
                recordList = Repository<UserGroupRecord>.Get();

                if (recordList.FindAll(a => a.Name == key).Count > 0)
                {
                    return null;
                }

                recordList.Add(new UserGroupRecord(name: item.Name, note: item.Note));

                Repository<UserGroupRecord>.SaveAndSet(recordList);
            }

            return item;

        }

        public override UserGroupModel Update(UserGroupModel item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            string key = item.GetKey();

            if (key == null)
                throw new ArgumentNullException("item.key");

            List<UserGroupRecord> recordList = new List<UserGroupRecord>();

            lock (_lock)
            {
                recordList = Repository<UserGroupRecord>.Get();

                var removeList = recordList.FindAll(a => a.Name == key);

                if (removeList.Count < 1)
                    return null;

                foreach(var i in removeList)
                {
                    recordList.Remove(i);
                }

                recordList.Add(new UserGroupRecord(name: item.Name, note: item.Note));

                Repository<UserGroupRecord>.SaveAndSet(recordList);
            }

            return item;
        }

        public override UserGroupModel Delete(string key)
        {
            if (key == null)
                throw new ArgumentNullException("item.key");

            List<UserGroupRecord> recordList = new List<UserGroupRecord>();

            lock (_lock)
            {
                recordList = Repository<UserGroupRecord>.Get();

                var removeList = recordList.FindAll(a => a.Name == key);

                if (removeList.Count < 1)
                    return null;

                foreach (var i in removeList)
                {
                    recordList.Remove(i);
                }

                Repository<UserGroupRecord>.SaveAndSet(recordList);

                return new UserGroupModel(name: recordList[0].Name, note: recordList[0].Note);
            }            
        }

        
    }
}
