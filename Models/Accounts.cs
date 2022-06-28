using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClientInfoAPI.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Transactions = new HashSet<Transactions>();
        }

        public int Code { get; set; }
        public int PersonCode { get; set; }
        public string AccountNumber { get; set; }
        public decimal OutstandingBalance { get; set; }

        public virtual Persons PersonCodeNavigation { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
