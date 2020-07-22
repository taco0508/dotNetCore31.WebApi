using AutoMapper;
using dotNetCore31.Business.Infrastructure.Mappings;
using dotNetCore31.Business.IServices;
using dotNetCore31.Business.Services;
using dotNetCore31.DataAccess.IRepositories;
using dotNetCore31.DataAccess.Repositories;
using dotNetCore31.WebApi.Infrastructure.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotNetCore31.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Repository
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            //Service
            services.AddTransient<ICustomerService, CustomerService>();

            //AutoMapper:
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ControllerMappingProfile>();
                cfg.AddProfile<ServiceMappingProfile>();
            });
            services.AddScoped<IMapper>(s => config.CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
