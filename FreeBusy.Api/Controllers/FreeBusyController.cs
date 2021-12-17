using System;
using System.Collections.Generic;
using System.Linq;
using FreeBusy.Api.Services;
using FreeBusy.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FreeBusy.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FreeBusyController : ControllerBase
    {
        private readonly IFreeBusyService service;

        public FreeBusyController(IFreeBusyService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Index()
        {
            return service.GetEmployees().ToList();
        }

        [HttpPost("available")]
        public ActionResult<IEnumerable<Employee>> Available([FromBody]JObject data)
        {
            var time = DateTime.Parse(data["time"].ToString());
            var duration = (int)data["duration"];
            return service.GetAvailableEmployees(time, duration).ToList();
        }

        [HttpPost("busytime")]
        public ActionResult<IEnumerable<BusyTime>> Busy([FromBody]JObject data)
        {
            var employeeId = data["employeeId"].ToString();
            return service.GetBusyTimesForEmployee(employeeId).ToList();
        }
    }
}
