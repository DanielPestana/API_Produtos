using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Product;
using Moq;

namespace Api.Service.Test.Product
{
    public class TesteCreate : ProductTestes
    {

        private IProductService _service;

        private Mock<IProductService> _serviceMock;

        [Fact]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IProductService>();
            _serviceMock.Setup(m => m.Create(productDtoCreate)).ReturnsAsync(productDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Create(productDtoCreate);

            Assert.NotNull(result);
            Assert.Equal(Code, result.Code);
            Assert.Equal(Description, result.Description);
            Assert.Equal(Status, result.Status);
            Assert.Equal(DateFabrication, result.DateFabrication);
            Assert.Equal(DateExpiry, result.DateExpiry);
            Assert.Equal(SupplierCode, result.SupplierCode);
            Assert.Equal(SupplierDescription, result.SupplierDescription);
            Assert.Equal(SupplierCnpj, result.SupplierCnpj);

        }

    }
}
