using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerInfo.Entities;

namespace CustomerInfo.Data
{    public class CustomerData
    {
        public static List<Entities.CustomerInfo> SuperCustomers = new List<Entities.CustomerInfo>
        {
            new Entities.CustomerInfo { Id = 0, FirstName = "Peter", LastName = "Parker", MemberName = "Peter Parker", PlaceOfBirth = "New York", Gender = "Male", Points = 50 },
            new Entities.CustomerInfo { Id = 1, FirstName = "Leena", LastName = "Wayne", MemberName = "Leena Wayne", PlaceOfBirth = "Gotham City", Gender = "Female", Points = 100 },
            new Entities.CustomerInfo { Id = 2, FirstName = "Tony", LastName = "Stark", MemberName = "Tony Stark", PlaceOfBirth = "Long Island, New York", Gender = "Male", Points = 10},
            new Entities.CustomerInfo { Id = 3, FirstName = "Bruce", LastName = "Banner", MemberName = "Bruce Banner", PlaceOfBirth = "Dayton", Gender = "Male", Points = 30 },
            new Entities.CustomerInfo { Id = 4, FirstName = "Sofi", LastName = "Howlett", MemberName = "Sofi Howlett", PlaceOfBirth = "Alberta", Gender = "Female", Points = 60 },
            new Entities.CustomerInfo { Id = 5, FirstName = "Stephen", LastName = "Strange", MemberName = "Stephen Strange", PlaceOfBirth = "Philadelphia", Gender = "Male", Points = 90 },
        };
    }
}