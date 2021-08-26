using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Business.Services.Interfaces;
using Covid19.Bussiness.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Covid19Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Covid19Controller> _logger;
        private readonly ICovid19BLL _covid19Bll;

        public Covid19Controller(ILogger<Covid19Controller> logger, ICovid19BLL covid19Bll)
        {
            _logger = logger;
            _covid19Bll = covid19Bll;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listCovid19 = await _covid19Bll.CovidTOPContries();
            if (listCovid19 is null || !listCovid19.Any() )
            {
                return BadRequest("Sorry no update today");
            }

            return Ok(listCovid19);
        }
    }
}