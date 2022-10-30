using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Product;
using Api.Domain.Interfaces.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Product
{
    public class RetornoCreate
    {
        private ProductsController _controller;

        [Fact]
        public async Task E_Possivel_Invocar_A_Controller_Create()
        {
            var serviceMock = new Mock<IProductService>();

            var code = Faker.RandomNumber.Next();
            var description = Faker.Lorem.Sentence();

            serviceMock.Setup(m => m.Create(It.IsAny<ProductDtoCreate>())).ReturnsAsync(
                new ProductDtoCreateResult
                {
                    Code = code,
                    Description = description
                }
            );

            _controller = new ProductsController(serviceMock.Object);
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("https://localhost:5000");
            _controller.Url = url.Object;

            var productDtoCreate = new ProductDtoCreate
            {
                Code = code,
                Description = description
            };

            var result = await _controller.Create(productDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as ProductDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(productDtoCreate.Code, resultValue.Code);
            Assert.Equal(productDtoCreate.Description, resultValue.Description);
        }
    }
}
