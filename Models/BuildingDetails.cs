using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class BuildingDetails
    {
        public long Id { get; set; }
        public string InformationKey { get; set; }
        public string Value { get; set; }
        public long? BuildingId { get; set; }

        public virtual Buildings Building { get; set; }
    }
}
