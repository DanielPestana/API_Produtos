using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Product;
using Api.Domain.Interfaces.Services.Product;
using Moq;

namespace Api.Service.Test.Product
{
    public class TesteGetAll : ProductTestes
    {
        private IProductService _service;

        private Mock<IProductService> _serviceMock;


        [Fact]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.GetAll(1)).ReturnsAsync(listaProductDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll(1);

            Assert.NotNull(result);
            Assert.True(result.Count() == 10);


            var _listResult = new List<ProductDto>();
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.GetAll(1)).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll(1);
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
