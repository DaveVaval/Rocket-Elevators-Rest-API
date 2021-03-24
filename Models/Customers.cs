using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Buildings = new HashSet<Buildings>();
        }

        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string FullNameCompanyContact { get; set; }
        public string CompanyContactPhone { get; set; }
        public string CompanyContactEmail { get; set; }
        public string CompanyDescription { get; set; }
        public string FullNameServiceTechnicalAuthority { get; set; }
        public string TechnicalAuthorityPhone { get; set; }
        public string TechnicalAuthorityEmail { get; set; }
        public long? UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Buildings> Buildings { get; set; }
    }
}
