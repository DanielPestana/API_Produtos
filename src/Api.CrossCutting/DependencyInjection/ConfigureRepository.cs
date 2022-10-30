using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository.Product;
using Api.Domain.Interfaces.Services.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IProductRepository<>), typeof(ProductRepository<>));

            serviceCollection.AddDbContext<MyContext>(
            options => options.UseSqlServer("Server=.\\;Initial Catalog=Dbapi;MultipleActiveResultSets=true;User ID=sa;Password=Admin@123")
            );

        }
    }
}

