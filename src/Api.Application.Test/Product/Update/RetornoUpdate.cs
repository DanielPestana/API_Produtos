using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Product;
using Api.Domain.Interfaces.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Product.Update
{
    public class RetornoUpdate
    {
        private ProductsController _controller;

        [Fact]
        public async Task E_Possivel_Invocar_A_Controller_Update()
        {
            var serviceMock = new Mock<IProductService>();

            var code = Faker.RandomNumber.Next();
            var description = Faker.Lorem.Sentence();

            serviceMock.Setup(m => m.Update(It.IsAny<ProductDtoUpdate>())).ReturnsAsync(
                new ProductDtoUpdateResult
                {
                    Code = code,
                    Description = description
                }
            );

            _controller = new ProductsController(serviceMock.Object);

            var productDtoUpdate = new ProductDtoUpdate
            {
                Code = code,
                Description = description
            };


            var result = await _controller.Update(productDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as ProductDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(productDtoUpdate.Code, resultValue.Code);
            Assert.Equal(productDtoUpdate.Description, resultValue.Description);
        }
    }
}
