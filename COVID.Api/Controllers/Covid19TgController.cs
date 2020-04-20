using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using COVID.Api.Data;
using COVID.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace COVID.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Covid19TgController : ControllerBase
    {
        [HttpGet]
        public async Task<List<CovidTgResume>> Get()
        {
            return await InfosCovidProvider.GetLastAsync();
        }
    }
}