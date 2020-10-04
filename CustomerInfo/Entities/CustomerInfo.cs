using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInfo.Entities
{
    public class CustomerInfo
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MemberName { get; set; }

        public string PlaceOfBirth { get; set; }

        public string Gender { get; set; }

        public int Points { get; set; }
    }
}