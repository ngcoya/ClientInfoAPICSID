using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClientInfoAPI.Models
{
    public partial class Persons
    {
        public Persons()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
