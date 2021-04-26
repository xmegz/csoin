using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csoin.Server.Interfaces;
using Csoin.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Csoin.Server.Api
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(ILogger<UserController> logger, IUserService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpGet]
        public IEnumerable<UserModel> GetAll()
        {
            return this._service.GetAll();
        }

        [HttpPost]
        public void Add(UserModel item)
        {
            this._service.Add(item);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Update(UserModel item)
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
