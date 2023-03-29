using System;
using System.Collections.Generic;

namespace restate_server_core_1.Models
{
    public partial class Photo
    {
        public int Id { get; set; }
        public string Key { get; set; } = null!;
        public int AdId { get; set; }
        public Ad Ad { get; set; }
    }
}
