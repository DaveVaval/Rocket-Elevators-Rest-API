using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class BlazerDashboards
    {
        public long Id { get; set; }
        public long? CreatorId { get; set; }
        public string Name { get; set; }
    }
}
