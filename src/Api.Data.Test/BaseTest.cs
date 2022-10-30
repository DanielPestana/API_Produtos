using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test;

public abstract class BaseTest
{
    public BaseTest()
    {

    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbapi";

        // private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            var serviceColletion = new ServiceCollection();
            serviceColletion.AddDbContext<MyContext>(o =>
                o.UseMySql($"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=root;Password=Admin@123"),
                ServiceLifetime.Transient
            );

            ServiceProvider = serviceColletion.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
