using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Product;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Api.Data.Repository.Product;
using Api.Data.Context;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {

        protected readonly MyContext _context;

        public ConfigureService(MyContext context)
        {
            _context = context;
        }


        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProductService, ProductService>();
        }
    }
}
