using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class Addresses
    {
        public long Id { get; set; }
        public string TypeOfAddress { get; set; }
        public string Status { get; set; }
        public string Entity { get; set; }
        public string NumberAndStreet { get; set; }
        public string SuiteOrApartment { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public string GoogleMap { get; set; }
    }
}
