using Bussines.Abstract;
using Bussines.FluentValidations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Containers
{
    public static class MyServices
    {
        public static IServiceCollection MyServiceInstance(this IServiceCollection services)
        {
            services.AddDbContext<FerayContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAimService, AimService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            
            services.AddScoped<IProductImagesService, ProductImagesService>();
            services.AddScoped<IPropertiesService, PropertiesService>();
            services.AddScoped<IUsersService, UsersService>();


            services.AddSingleton<IValidator<Product>, ValidationProduct>();
          
            services.AddSingleton<IValidator<Properties>, ValidationProperties>();
            services.AddSingleton<IValidator<Users>, ValidationUsers>();



            return services;
        }
    }
}
