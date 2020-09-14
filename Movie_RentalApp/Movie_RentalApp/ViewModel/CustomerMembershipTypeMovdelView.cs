using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_RentalApp.Models;

namespace Movie_RentalApp.ViewModel
{
    public class CustomerMembershipTypeMovdelView
    {
        public IEnumerable<MembershipType> MembershiptypeList { get; set; }
        public Customers customers { get; set; }
    }
}