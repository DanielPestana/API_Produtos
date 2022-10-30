using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.Product;
using Api.Domain.Utils.Enums;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository.Product
{
    public class ProductRepository<T> : IProductRepository<T> where T : ProductEntity
    {

        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public ProductRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }


        public async Task<T> DeleteAsync(Guid id)
        {
            try
            {

                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                {
                    return null;
                }

                var atualizado = result;

                atualizado.Status = StatusEnum.Inativo;
                atualizado.UpdateAt = DateTime.UtcNow;

                _context.Entry(result).CurrentValues.SetValues(atualizado);
                await _context.SaveChangesAsync();
                return atualizado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.Status = StatusEnum.Ativo;
                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> SelectAsync(long code)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Code.Equals(code));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync(int page)
        {
            try
            {
                var result = await _dataset.Skip(page).Take(5).AsNoTracking().ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                {
                    return null;
                }

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
