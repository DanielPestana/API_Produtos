using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Product;
using Api.Domain.Entities;
using Api.Domain.Models;

namespace Api.Service.Test.AutoMapper
{
    public class ProductMapper : BaseTesteService
    {
        [Fact]
        public void E_Possivel_Mapear_Os_Modelos()
        {
            var model = new ProductModel
            {
                Id = Guid.NewGuid(),
                Code = Faker.RandomNumber.Next(),
                Description = Faker.Lorem.Sentence(),
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<ProductEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Code = Faker.RandomNumber.Next(),
                    Description = Faker.Lorem.Sentence(),
                    UpdateAt = DateTime.UtcNow
                };
                listaEntity.Add(item);
            }

            var entity = Mapper.Map<ProductEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Code, model.Code);
            Assert.Equal(entity.Description, model.Description);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            var productDto = Mapper.Map<ProductDto>(entity);
            Assert.Equal(productDto.Code, entity.Code);
            Assert.Equal(productDto.Description, entity.Description);

            var listaDto = Mapper.Map<List<ProductDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());

            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Code, listaEntity[i].Code);
                Assert.Equal(listaDto[i].Description, listaEntity[i].Description);
            }

            var productDtoCreateResult = Mapper.Map<ProductDtoCreateResult>(entity);
            Assert.Equal(productDtoCreateResult.Code, entity.Code);
            Assert.Equal(productDtoCreateResult.Description, entity.Description);


            var productDtoUpdateResult = Mapper.Map<ProductDtoUpdateResult>(entity);
            Assert.Equal(productDtoUpdateResult.Code, entity.Code);
            Assert.Equal(productDtoUpdateResult.Description, entity.Description);

            var productModel = Mapper.Map<ProductModel>(productDto);
            Assert.Equal(productModel.Code, productDto.Code);
            Assert.Equal(productModel.Description, productDto.Description);

            var productDtoCreate = Mapper.Map<ProductDtoCreate>(productModel);
            Assert.Equal(productDtoCreate.Code, productModel.Code);
            Assert.Equal(productDtoCreate.Description, productModel.Description);

            var productDtoUpdate = Mapper.Map<ProductDtoUpdate>(productModel);
            Assert.Equal(productDtoUpdate.Code, productModel.Code);
            Assert.Equal(productDtoUpdate.Description, productModel.Description);


        }
    }
}
