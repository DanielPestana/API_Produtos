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
    public class RetornoGet
    {
        private ProductsController _controller;

        [Fact]
        public async Task E_Possivel_Invocar_A_Controller_Get()
        {
            var serviceMock = new Mock<IProductService>();
            var code = Faker.RandomNumber.Next();
            var description = Faker.Lorem.Sentence();

            serviceMock.Setup(m => m.GetByCode(It.IsAny<long>())).ReturnsAsync(
                new ProductDto
                {
                    Code = code,
                    Description = description
                }
            );

            _controller = new ProductsController(serviceMock.Object);
            var result = await _controller.Get(code);
            Assert.True(result is OkObjectResult);


        }
    }
}
