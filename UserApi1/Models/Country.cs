using System;
using System.Collections.Generic;

#nullable disable

namespace UserApi1.Models
{
    public partial class Country
    {
        public Country()
        {
            Usertable1s = new HashSet<Usertable1>();
        }

        public decimal CountryId { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Usertable1> Usertable1s { get; set; }
    }
}
