using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeBusy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FreeBusy.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FreeBusyController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<FreeBusyController> logger;
        private readonly DBCore dbCore;

        public FreeBusyController(ILogger<FreeBusyController> logger)
        {
            this.logger = logger;
            dbCore = new DBCore();

        }

        [HttpGet]
        public Task<IList<Employee>> Get(string meetingTime, int duration)
        {
            return Task.FromResult(dbCore.AvilablEmployees(DateTime.Parse(meetingTime), duration));
        }
    }
}
