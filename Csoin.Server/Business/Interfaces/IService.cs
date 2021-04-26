using Csoin.Server.Api;
using Csoin.Server.Models;
using System.Collections.Generic;

namespace Csoin.Server.Interfaces
{
    public interface IAService<T> where T : AModel
    {
        T Add(T item);
        T Delete(string key);
        T Get(string key);
        List<T> GetAll();
        T Update(T item);
    }

    public interface IEventService : IAService<EventModel> { }
    public interface IEventTypeService : IAService<EventTypeModel> { }
    public interface IUserService : IAService<UserModel> { }
    public interface IUserGroupService : IAService<UserGroupModel> { }
}