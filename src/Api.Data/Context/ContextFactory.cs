using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            //var connectionString = "Server=localhost;Port=3306;DataBase=dbAPI;Uid=root;Pwd=Admin@123";
            var connectionString = "Server=.\\;Initial Catalog=Dbapi;MultipleActiveResultSets=true;User ID=sa;Password=Admin@123";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
