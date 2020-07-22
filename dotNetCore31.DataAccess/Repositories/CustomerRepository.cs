using System.Collections.Generic;
using dotNetCore31.DataAccess.DataModels;
using dotNetCore31.DataAccess.IRepositories;

namespace dotNetCore31.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<CustomersDataModel> GetCustomerList(IEnumerable<int> customerIds)
        {
            return new List<CustomersDataModel>
            {
                new CustomersDataModel { CustomerId = 1, CustomerName = "Taco" },
                new CustomersDataModel { CustomerId = 2, CustomerName = "Taco2" },
            };
        }
    }
}
