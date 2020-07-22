using System.Collections.Generic;
using AutoMapper;
using dotNetCore31.Business.Dtos;
using dotNetCore31.Business.IServices;
using dotNetCore31.DataAccess.DataModels;
using dotNetCore31.DataAccess.IRepositories;

namespace dotNetCore31.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            IMapper mapper,
            ICustomerRepository customerRepository)
        {
            this._mapper = mapper;
            this._customerRepository = customerRepository;
        }

        public IEnumerable<CustomersDto> GetCustomerList(IEnumerable<int> customerIds)
        {
            var data = this._customerRepository.GetCustomerList(customerIds);
            var result = this._mapper.Map<IEnumerable<CustomersDataModel>, IEnumerable<CustomersDto>>(data);
            return result;
        }
    }
}
