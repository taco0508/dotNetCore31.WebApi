using System.Collections.Generic;
using AutoMapper;
using dotNetCore31.Business.Dtos;
using dotNetCore31.Business.IServices;
using dotNetCore31.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dotNetCore31.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(
            IMapper mapper,
            ICustomerService customerService)
        {
            this._mapper = mapper;
            this._customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<CustomersViewModel> GetCustomerList(IEnumerable<int> customerIds)
        {
            var data = this._customerService.GetCustomerList(customerIds);
            var result = this._mapper.Map<IEnumerable<CustomersDto>, IEnumerable<CustomersViewModel>>(data);
            return result;
        }
    }
}
