using System;
using System.Collections.Generic;

#nullable disable

namespace UserApi1.Models
{
    public partial class Usertable1
    {
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public decimal CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Country Country { get; set; }
    }
}
