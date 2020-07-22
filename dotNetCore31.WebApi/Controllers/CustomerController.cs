using System.Collections.Generic;
using System.Threading.Tasks;
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

        /// <summary>
        /// 取得客戶清單(單筆)
        /// </summary>
        /// <param name="customerId">客戶編號</param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerListAsync(string customerId)
        {
            var data = await this._customerService.GetCustomerListAsync(new[] { customerId });
            var result = this._mapper.Map<IEnumerable<CustomersDto>, IEnumerable<CustomersViewModel>>(data);
            return Ok(result);
        }

        /// <summary>
        /// 取得客戶清單(多筆)
        /// </summary>
        /// <param name="customerIds">客戶編號(多筆)</param>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<IActionResult> GetCustomerListAsync([FromBody] IEnumerable<string> customerIds)
        {
            var data = await this._customerService.GetCustomerListAsync(customerIds);
            var result = this._mapper.Map<IEnumerable<CustomersDto>, IEnumerable<CustomersViewModel>>(data);
            return Ok(result);
        }

        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="customersCreateViewModel">客戶CreateViewModel</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomersCreateViewModel customersCreateViewModel)
        {
            var data = this._mapper.Map<CustomersCreateViewModel, CustomersCreateDto>(customersCreateViewModel);
            var result = await this._customerService.CreateCustomerAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 更新客戶資料
        /// </summary>
        /// <param name="customersUpdateViewModel">客戶UpdateViewModel</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] CustomersUpdateViewModel customersUpdateViewModel)
        {
            var data = this._mapper.Map<CustomersUpdateViewModel, CustomersUpdateDto>(customersUpdateViewModel);
            var result = await this._customerService.UpdateCustomerAsync(data);
            return Ok(result);
        }
    }
}
