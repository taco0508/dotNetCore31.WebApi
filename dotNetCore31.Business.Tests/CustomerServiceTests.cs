using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using dotNetCore31.Business.Dtos;
using dotNetCore31.Business.Infrastructure.Mappings;
using dotNetCore31.Business.IServices;
using dotNetCore31.Business.Services;
using dotNetCore31.DataAccess.DataModels;
using dotNetCore31.DataAccess.IRepositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace dotNetCore31.Business.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private IMapper _mapper;
        private ICustomerRepository _customerRepository;

        public CustomerServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceMappingProfile>();
            });

            this._mapper = config.CreateMapper();
            this._customerRepository = NSubstitute.Substitute.For<ICustomerRepository>();
        }

        private ICustomerService GetSystemUnderTest()
        {
            return new CustomerService(this._mapper, this._customerRepository);
        }

        //---------------------------------------------------------------

        [TestMethod]
        [Owner("Taco")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetCustomerListAsync")]
        public async Task GetCustomerListAsync_輸入正確的customerIds_應該回傳正確資料()
        {
            // arrange
            var customerIds = new[]
            {
                "ALFKI",
                "ANATR",
                "ANTON"
            };

            IEnumerable<CustomersDataModel> customersDataModels = new[]
            {
                new CustomersDataModel
                {
                    CustomerID = "ALFKI",
                    Country = "Germany",
                    City = "Berlin"
                },
                new CustomersDataModel
                {
                    CustomerID = "ANATR",
                    Country = "Mexico",
                    City = "Mexico D.F."
                },
                new CustomersDataModel
                {
                    CustomerID = "ANTON",
                    Country = "Mexico",
                    City = "Mexico D.F."
                },
            };

            this._customerRepository.GetCustomerListAsync(customerIds).Returns(customersDataModels);

            var sut = GetSystemUnderTest();

            // expected
            IEnumerable<CustomersDto> expected = new[]
            {
                new CustomersDto
                {
                    CustomerID = "ALFKI",
                    Country = "Germany",
                    City = "Berlin"
                },
                new CustomersDto
                {
                    CustomerID = "ANATR",
                    Country = "Mexico",
                    City = "Mexico D.F."
                },
                new CustomersDto
                {
                    CustomerID = "ANTON",
                    Country = "Mexico",
                    City = "Mexico D.F."
                },
            };

            // act
            var actual = await sut.GetCustomerListAsync(customerIds);

            // assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        [Owner("Taco")]
        [TestCategory("CustomerService")]
        [TestProperty("CustomerService", "GetCustomerListAsync")]
        public async Task CreateCustomerAsync_正確的新增_應該回傳1()
        {
            // arrange
            var customersCreateDto = new CustomersCreateDto
            {
                CustomerID = "Taco1",
                CompanyName = "Alfreds Futterkiste"
            };

            this._customerRepository.CreateCustomerAsync(Arg.Is<CustomersCreateDataModel>
                (
                    c => c.CustomerID == "Taco1" && c.CompanyName == "Alfreds Futterkiste"
                )).Returns(1);

            var sut = GetSystemUnderTest();

            int expected = 1;

            // act
            var actual = await sut.CreateCustomerAsync(customersCreateDto);

            // assert
            actual.Should().Be(expected);

            await this._customerRepository.Received(1).CreateCustomerAsync
            (  
                Arg.Is<CustomersCreateDataModel>
                (
                    c => c.CustomerID == "Taco1" && c.CompanyName == "Alfreds Futterkiste"
                )
            );
        }
    }
}
