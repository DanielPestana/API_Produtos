using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Product;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.Product;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository<ProductEntity> _repository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository<ProductEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool validaFabricacao(DateTime? fabricacao, DateTime? validade)
        {
            if (fabricacao.HasValue && validade.HasValue)
            {
                DateTime fabricacaoManipulada = fabricacao ?? DateTime.UtcNow;
                DateTime validadeManipulada = validade ?? DateTime.UtcNow;
                var result = DateTime.Compare(fabricacaoManipulada, validadeManipulada);
                if (result > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<ProductDtoCreateResult> Create(ProductDtoCreate product)
        {

            if (!validaFabricacao(product.DateFabrication, product.DateExpiry))
            {
                throw new Exception("Data de validade não pode ser menor que a data de fabricação.");
            }

            var model = _mapper.Map<ProductModel>(product);
            var entity = _mapper.Map<ProductEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<ProductDtoCreateResult>(result);
        }

        public async Task<ProductDtoUpdateResult> Update(ProductDtoUpdate product)
        {

            if (!validaFabricacao(product.DateFabrication, product.DateExpiry))
            {
                throw new Exception("Data de validade não pode ser menor que a data de fabricação.");
            }
            var model = _mapper.Map<ProductModel>(product);
            var entity = _mapper.Map<ProductEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ProductDtoUpdateResult>(result);
        }

        public async Task<ProductEntity> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAll(int page)
        {
            var listEntity = await _repository.SelectAsync(page);
            return _mapper.Map<IEnumerable<ProductDto>>(listEntity);
        }

        public async Task<ProductDto> GetByCode(long code)
        {
            var entity = await _repository.SelectAsync(code);
            return _mapper.Map<ProductDto>(entity);
        }

    }
}
