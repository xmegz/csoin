using Csoin.Server.Interfaces;
using Csoin.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Csoin.Server.Api
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class EventTypeController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IEventTypeService _service;

        public EventTypeController(ILogger<UserController> logger, IEventTypeService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpGet]
        public IEnumerable<EventTypeModel> GetAll()
        {
            return this._service.GetAll();
        }

        [HttpPost]
        public void Add(EventTypeModel item)
        {
            this._service.Add(item);
        }

        [HttpPut]
        public void Update(EventTypeModel item)
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
