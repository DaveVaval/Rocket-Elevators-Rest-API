using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class Users
    {
        public Users()
        {
            Customers = new HashSet<Customers>();
            Employees = new HashSet<Employees>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public string ResetPasswordToken { get; set; }
        public bool? SupervisorRole { get; set; }
        public bool? UserRole { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
