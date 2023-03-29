using System;
using System.Collections.Generic;

namespace restate_server_core_1.Models
{
    public partial class Origin
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
    }
}
