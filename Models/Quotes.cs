using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class Quotes
    {
        public long Id { get; set; }
        public string BuildingType { get; set; }
        public int? NumberOfApartments { get; set; }
        public int? NumberOfFloors { get; set; }
        public int? NumberOfBasements { get; set; }
        public int? NumberOfElevators { get; set; }
        public int? MaximumOccupancy { get; set; }
        public string ProductLine { get; set; }
        public int? ElevatorsRequired { get; set; }
        public int? ElevatorAmount { get; set; }
        public string ElevatorUnitPrice { get; set; }
        public string ElevatorTotalPrice { get; set; }
        public string ElevatorInstallationFees { get; set; }
        public string FinalPrice { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
    }
}
