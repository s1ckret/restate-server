using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restate_server_core_1.Models;

namespace restate_server_core_1.Controllers
{
    [Route("api/buildings/geojson")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly adsContext _context;

        public BuildingsController(adsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var buildings = _context.Buildings
            .Select(b => new { Id = b.Id, Geojson = b.Geojson })
            .ToList();

            return Ok(buildings);
        }
    }
}
