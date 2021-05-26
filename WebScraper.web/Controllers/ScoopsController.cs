using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraper.scraping;

namespace WebScraper.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoopsController : ControllerBase
    {
        [HttpGet]
        [Route("GetScoops")]
        public List<Scoop> GetScoops()
        {
            return Scraper.ScrapeLakewoodScoop();
        }
    }
}
