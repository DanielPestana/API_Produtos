using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Product;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Product
{
    public interface IProductService
    {
        Task<ProductDto> GetByCode(long code);
        Task<IEnumerable<ProductDto>> GetAll(int page); // Filtrando a partir de parâmetros e paginando a resposta
        Task<ProductDtoCreateResult> Create(ProductDtoCreate product); //Criar validação para o campo data de fabricação que não poderá ser maior ou igual a data de validade.
        Task<ProductDtoUpdateResult> Update(ProductDtoUpdate product); //Criar validação para o campo data de fabricação que não poderá ser maior ou igual a data de validade
        Task<ProductEntity> Delete(Guid id); //A exclusão deverá ser lógica, atualizando o campo situação com o valor Inativo.
    }
}
