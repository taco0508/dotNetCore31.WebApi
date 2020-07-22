using System.Collections.Generic;
using dotNetCore31.Business.Dtos;

namespace dotNetCore31.Business.IServices
{
    public interface ICustomerService
    {
        IEnumerable<CustomersDto> GetCustomerList(IEnumerable<int> customerIds);
    }
}
