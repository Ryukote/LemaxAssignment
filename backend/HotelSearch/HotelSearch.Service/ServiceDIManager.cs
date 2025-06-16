using System.Reflection;
using FluentValidation;
using HotelSearch.Application.Contracts;
using HotelSearch.Application.Payloads.Responses;
using HotelSearch.Application.Services;
using HotelSearch.Service.Payloads.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelSearch.Application
{
    public static class ServiceDIManager
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceAssembly = typeof(AddUpdateHotelRequest).Assembly;
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(serviceAssembly);
            
            services.AddTransient<IBaseService<AddUpdateHotelRequest, GetHotelResponse>, HotelService>();
            
            return services;
        }
    }
}
