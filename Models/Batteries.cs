using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class Batteries
    {
        public Batteries()
        {
            Columns = new HashSet<Columns>();
        }

        public long Id { get; set; }
        public long? BuildingId { get; set; }
        public string Status { get; set; }
        public DateTime? DateCommissioning { get; set; }
        public DateTime? DateLastInspection { get; set; }
        public string CertificateOfOperations { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public string BatteryType { get; set; }

        public virtual Buildings Building { get; set; }
        public virtual ICollection<Columns> Columns { get; set; }
    }
}
