using System.Collections.Generic;
using dotNetCore31.DataAccess.DataModels;

namespace dotNetCore31.DataAccess.IRepositories
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomersDataModel> GetCustomerList(IEnumerable<int> customerIds);
    }
}
