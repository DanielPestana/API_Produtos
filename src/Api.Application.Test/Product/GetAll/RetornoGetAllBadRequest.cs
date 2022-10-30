using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Product;
using Api.Domain.Interfaces.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Product.Get
{
    public class RetornoGetAllBadRequest
    {
        private ProductsController _controller;

        [Fact]
        public async Task E_Possivel_Invocar_A_Controller_GetAllBadRequest()
        {
            var serviceMock = new Mock<IProductService>();

            serviceMock.Setup(m => m.GetAll(1)).ReturnsAsync(
                new List<ProductDto>
                {
                    new ProductDto {
                        Code = Faker.RandomNumber.Next(),
                        Description = Faker.Lorem.Sentence()
                    },
                    new ProductDto {
                        Code = Faker.RandomNumber.Next(),
                        Description = Faker.Lorem.Sentence()
                    }
                }
            );

            _controller = new ProductsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Code", "É um campo Obrigatório");
            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
