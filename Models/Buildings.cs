using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class Buildings
    {
        public Buildings()
        {
            Batteries = new HashSet<Batteries>();
            BuildingDetails = new HashSet<BuildingDetails>();
        }

        public long Id { get; set; }
        public string AddressBuilding { get; set; }
        public string FullNameAdministrator { get; set; }
        public string EmailAdministrator { get; set; }
        public string PhoneAdministrator { get; set; }
        public string FullNameTechnicalContactBuilding { get; set; }
        public string TechnicalContactBuildingEmail { get; set; }
        public string TechnicalContactBuildingPhone { get; set; }
        public long? CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<Batteries> Batteries { get; set; }
        public virtual ICollection<BuildingDetails> BuildingDetails { get; set; }
    }
}
