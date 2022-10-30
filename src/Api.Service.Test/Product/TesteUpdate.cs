using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Product;
using Moq;

namespace Api.Service.Test.Product
{
    public class TesteUpdate : ProductTestes
    {
        private IProductService _service;

        private Mock<IProductService> _serviceMock;


        [Fact]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.Create(productDtoCreate)).ReturnsAsync(productDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Create(productDtoCreate);

            Assert.NotNull(result);
            Assert.Equal(Code, result.Code);
            Assert.Equal(Description, result.Description);


            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.Update(productDtoUpdate)).ReturnsAsync(productDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Update(productDtoUpdate);
            Assert.NotNull(productDtoUpdate);
            Assert.Equal(DescriptionAlterado, resultUpdate.Description);

        }
    }
}
