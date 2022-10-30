using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Data.Repository.Product;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Product;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ProductImplementation : ProductRepository<ProductEntity>
    {
        private DbSet<ProductEntity> _dataset;
        public ProductImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ProductEntity>();
        }
    }
}
