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
    public class RetornoUpdateBadRequest
    {
        private ProductsController _controller;

        [Fact]
        public async Task E_Possivel_Invocar_A_Controller_Update_Bad_Request()
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
            _controller.ModelState.AddModelError("Code", "É um campo Obrigatório");

            var productDtoUpdate = new ProductDtoUpdate
            {
                Code = code,
                Description = description
            };


            var result = await _controller.Update(productDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
