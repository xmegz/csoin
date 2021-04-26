using Csoin.Server.Api;
using Csoin.Server.Interfaces;
using Csoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csoin.Server.Services
{
    public class EventService : AService<EventModel>, IEventService
    {
        public override EventModel Add(EventModel item)
        {
            new UserGroupService().Get(item.UserGroup);
            new UserService().Get(item.User);
            new EventTypeService().Get(item.EventType);

            return base.Add(item);
        }

        public override EventModel Update(EventModel item)
        {
            new UserGroupService().Get(item.UserGroup);
            new UserService().Get(item.User);
            new EventTypeService().Get(item.EventType);

            return base.Update(item);
        }

    }
}
