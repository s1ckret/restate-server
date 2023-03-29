using Microsoft.AspNetCore.Mvc;
using restate_server_core_1.Models;

namespace restate_server_core_1.Controllers
{
    [Route("api/ads")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly adsContext _context;

        public AdsController(adsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int limit = 2, int buildingId = 0)
        {
            if (page < 1)
            {
                return BadRequest("Page parameter should be positive!");
            }

            if (limit <= 0 || limit > 20)
            {
                return BadRequest("Limit parameter should be in range[1, 20]");
            }

            page -= 1;

            if (buildingId <= 0)
            {
                int firstId = 1 + page * limit;
                var range = Enumerable.Range(firstId, limit);

                var postings = _context.Ads
                    .Where(it => range.Contains(it.Id))
                    .Select(it => new
                    {
                        building = new
                        {
                            id = it.Building.Id,
                            street = it.Building.Street,
                            houseNumber = it.Building.HouseNumber,
                            maxFloors = it.Building.MaxFloors,
                            lat = it.Building.Lat,
                            lon = it.Building.Lon
                        },
                        photo = it.Photos.ToList().Select(p => p.Key),
                        postedAtSec = it.PostedAtSec,
                        foundAtSec = it.FoundAtSec,
                        atFloor = it.AtFloor,
                        title = it.Title,
                        description = it.Description,
                        price = it.Price,
                        currency = it.Currency,
                        readyForLiving = it.ReadyForLiving,
                        roomQty = it.RoomQty

                    });

                return Ok(postings);
            } else
            {
                var postings = _context.Ads
                    .Where(it => it.BuildingId == buildingId)
                    .Select(it => new
                    {
                        building = new
                        {
                            id = it.Building.Id,
                            street = it.Building.Street,
                            houseNumber = it.Building.HouseNumber,
                            maxFloors = it.Building.MaxFloors,
                            lat = it.Building.Lat,
                            lon = it.Building.Lon
                        },
                        photo = it.Photos.ToList().Select(p => p.Key),
                        postedAtSec = it.PostedAtSec,
                        foundAtSec = it.FoundAtSec,
                        atFloor = it.AtFloor,
                        title = it.Title,
                        description = it.Description,
                        price = it.Price,
                        currency = it.Currency,
                        readyForLiving = it.ReadyForLiving,
                        roomQty = it.RoomQty

                    })
                    .Skip(page * limit)
                    .Take(limit);

                return Ok(postings);
            }
            
        }

    }
}
