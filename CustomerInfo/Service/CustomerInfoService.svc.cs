using CustomerInfo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace CustomerInfo.Service
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CustomerInfoService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public List<Entities.CustomerInfo> GetCustomers()
        {
            return CustomerData.SuperCustomers;
        }

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate="GetCustomer/{id}")]
        public Entities.CustomerInfo GetCustomer(string id)
        {
            return CustomerData.SuperCustomers.Find(sc => sc.Id == int.Parse(id));
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, 
            UriTemplate="AddCustomer", Method ="POST")]
        public Entities.CustomerInfo AddCustomer(Entities.CustomerInfo customer)
        {
            customer.Id = CustomerData.SuperCustomers.Max(sc => sc.Id) + 1;
            CustomerData.SuperCustomers.Add(customer);
            return customer;
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "UpdateCustomer/{id}", Method = "PUT")]
        public Entities.CustomerInfo UpdateCustomer(Entities.CustomerInfo updateCustomer, string id)
        { 
            Entities.CustomerInfo customer = CustomerData.SuperCustomers.Where(sc => sc.Id == int.Parse(id)).FirstOrDefault();

            customer.FirstName = updateCustomer.FirstName;
            customer.LastName = updateCustomer.LastName;
            customer.MemberName = updateCustomer.MemberName;
            customer.PlaceOfBirth = updateCustomer.PlaceOfBirth;
            customer.Gender = updateCustomer.Gender;
            customer.Points = updateCustomer.Points;

            return customer;
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "DeleteCustomer/{id}", Method = "DELETE")]
        public List<Entities.CustomerInfo> DeleteCustomer(string id)
        {
            CustomerData.SuperCustomers = CustomerData.SuperCustomers.Where(sc => sc.Id != int.Parse(id)).ToList();

            return CustomerData.SuperCustomers;
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "SearchCustomer/{searchText}", Method = "GET")]
        public List<Entities.CustomerInfo> SearchCustomer(string searchText)
        {
            List<Entities.CustomerInfo> result = CustomerData.SuperCustomers
                .Where<Entities.CustomerInfo>(sc => sc.FirstName.ToLower().Contains(searchText)
                                                  || sc.LastName.ToLower().Contains(searchText)
                                                  || sc.MemberName.ToLower().Contains(searchText)
                                                  || sc.PlaceOfBirth.ToLower().Contains(searchText)
                                                  || sc.Gender.ToLower().Equals(searchText)
                                                  || sc.Points.Equals(searchText))
                                                    .ToList<Entities.CustomerInfo>();
            return result;
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "GetSortedCustomerList/{type}", Method = "GET")]
        public List<Entities.CustomerInfo> GetSortedCustomerList(string type)
        {
            switch(type)
            {
                case "firstname":
                    return CustomerData.SuperCustomers.OrderBy(customer => customer.FirstName).ThenBy(customer => customer.LastName).ToList();
                case "lastname":
                    return CustomerData.SuperCustomers.OrderBy(customer => customer.LastName).ThenBy(customer => customer.FirstName).ToList();
                case "membername":
                    return CustomerData.SuperCustomers.OrderBy(customer => customer.MemberName).ThenBy(customer => customer.FirstName).ToList();
                case "pob":
                    return CustomerData.SuperCustomers.OrderBy(customer => customer.PlaceOfBirth).ThenBy(customer => customer.FirstName).ToList();
                case "gender":
                    return CustomerData.SuperCustomers.OrderBy(customer => customer.Gender).ThenBy(customer => customer.FirstName).ToList();
                case "points":                   
                default:
                    return CustomerData.SuperCustomers.OrderBy(customer => customer.Points).ThenBy(customer => customer.FirstName).ToList();
            }
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "Team/{id1}/{id2}", Method = "GET")]
        public string Team(string id1, string id2)
        {
            Entities.CustomerInfo customer1 = CustomerData.SuperCustomers.Find(customer => customer.Id == int.Parse(id1));
            Entities.CustomerInfo customer2 = CustomerData.SuperCustomers.Find(customer => customer.Id == int.Parse(id2));

            if (customer1.Points > customer2.Points)
            {
                return $"{customer1.MemberName} wins!"; 
            } 
            else if (customer2.Points > customer1.Points)
            {
                return $"{customer2.MemberName} wins!";
            }

            return "It's a tie!";
        }
    }
}
