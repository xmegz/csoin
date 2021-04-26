using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csoin.Server.Interfaces;
using Csoin.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Csoin.Server.Api
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class UserGroupController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserGroupService _service;

        public UserGroupController(ILogger<UserController> logger, IUserGroupService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpGet]
        public IEnumerable<UserGroupModel> GetAll()
        {
            return this._service.GetAll();
        }

        [HttpPost]
        public void Add(UserGroupModel item)
        {
            this._service.Add(item);
        }

        [HttpPut]
        public void Update(UserGroupModel item)
        {
            this._service.Update(item);
        }

        [HttpDelete]
        public void Delete(string key)
        {
            this._service.Delete(key);
        }


    }
}
