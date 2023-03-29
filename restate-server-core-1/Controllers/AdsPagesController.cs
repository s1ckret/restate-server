using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restate_server_core_1.Models;

namespace restate_server_core_1.Controllers
{
    [Route("api/ads/pages")]
    [ApiController]
    public class AdsPagesController : ControllerBase
    {
        private readonly adsContext _context;

        public AdsPagesController(adsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int size = 2, int buildingId = 0)
        {

            int ads = 0;
            if (buildingId <= 0)
            {
                ads = _context.Ads.Count();
            }
            else
            {
                ads = _context.Ads.Where(it => it.BuildingId == buildingId).Count();
            }
            int pages = ads / size;
            return Ok(pages);
        }
    }
}
