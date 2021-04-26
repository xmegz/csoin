using Csoin.Server.Api;
using Csoin.Server.Interfaces;
using Csoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csoin.Server.Services
{
    public class UserService:AService<UserModel>, IUserService
    {
        public override UserModel Add(UserModel item)
        {
            new UserGroupService().Get(item.UserGroup);

            return base.Add(item);
        }

        public override UserModel Update(UserModel item)
        {
            new UserGroupService().Get(item.UserGroup);

            return base.Update(item);
        }
    }
}
