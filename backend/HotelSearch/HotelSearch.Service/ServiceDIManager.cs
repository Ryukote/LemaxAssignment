using FluentValidation;
using HotelSearch.Application.Contracts;
using HotelSearch.Application.Payloads.Requests;
using HotelSearch.Application.Payloads.Responses;
using HotelSearch.Application.Services;
using HotelSearch.Application.Validations;
using HotelSearch.Service.Payloads.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelSearch.Application
{
    public static class ServiceDIManager
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceAssembly = typeof(AddUpdateHotelRequest).Assembly;

            //services.AddValidatorsFromAssemblyContaining<AddUpdateHotelRequestValidator>();

            services.AddAutoMapper(serviceAssembly);

            services.AddTransient<IBaseService<AddUpdateHotelRequest, GetHotelResponse, PaginateRequest>, HotelService>();
            services.AddTransient<IHotelSearchService<GetHotelDistanceResponse, PaginateHotelRequest>, HotelSearchService>();

            return services;
        }
    }
}
