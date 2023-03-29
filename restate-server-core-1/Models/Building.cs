using System;
using System.Collections.Generic;

namespace restate_server_core_1.Models
{
    public partial class Building
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string HouseNumber { get; set; } = null!;
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string Geojson { get; set; } = null!;
        public int? MaxFloors { get; set; }
        public int OsmId { get; set; }
        public ICollection<Ad> Ads { get; set; }

    }
}
