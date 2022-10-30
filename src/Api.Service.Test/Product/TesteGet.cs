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
    public class TesteGet : ProductTestes
    {
        private IProductService _service;

        private Mock<IProductService> _serviceMock;

        [Fact]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.GetByCode(Code)).ReturnsAsync(productDto);

            _service = _serviceMock.Object;
            var result = await _service.GetByCode(Code);

            Assert.NotNull(result);
            Assert.True(result.Code == Code);

            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.GetByCode(Faker.RandomNumber.Next())).Returns(Task.FromResult((ProductDto)productDto));
            _service = _serviceMock.Object;

            var _record = await _service.GetByCode(Code);
            Assert.Null(_record);
        }


    }
}
