using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class BlazerDashboardQueries
    {
        public long Id { get; set; }
        public long? DashboardId { get; set; }
        public long? QueryId { get; set; }
        public int? Position { get; set; }
    }
}
