using AutoMapper;
using dotNetCore31.Business.Dtos;
using dotNetCore31.DataAccess.DataModels;

namespace dotNetCore31.Business.Infrastructure.Mappings
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<CustomersDataModel, CustomersDto>().ReverseMap();
            this.CreateMap<CustomersCreateDataModel, CustomersCreateDto>().ReverseMap();
            this.CreateMap<CustomersUpdateDataModel, CustomersUpdateDto>().ReverseMap();
        }
    }
}
