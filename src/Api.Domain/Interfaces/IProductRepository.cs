using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Product
{
    public interface IProductRepository<T> where T : ProductEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> DeleteAsync(Guid id);
        Task<T> SelectAsync(long code);
        Task<IEnumerable<T>> SelectAsync(int page);
    }
}
