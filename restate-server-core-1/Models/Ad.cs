using System;
using System.Collections.Generic;

namespace restate_server_core_1.Models
{
    public partial class Ad
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public string Url { get; set; } = null!;
        public int TheirId { get; set; }
        public int RoomQty { get; set; }
        public float TotalArea { get; set; }
        public int AtFloor { get; set; }
        public float Price { get; set; }
        public string Currency { get; set; } = null!;
        public bool ReadyForLiving { get; set; }
        public string Description { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int FoundAtSec { get; set; }
        public int PostedAtSec { get; set; }
        public ICollection<Photo> Photos { get; set; }

    }
}
