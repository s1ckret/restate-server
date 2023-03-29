using System;
using System.Collections.Generic;

namespace restate_server_core_1.Models
{
    public partial class PhotoFeature
    {
        public int PhotoId { get; set; }
        public int ModelId { get; set; }
        public int Version { get; set; }
        public string? Features { get; set; }
    }
}
