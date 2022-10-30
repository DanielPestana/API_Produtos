using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository.Product;
using Api.Domain.Entities;
using Api.Domain.Utils.Enums;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using static Api.Data.Test.BaseTest;

namespace Api.Data.Test
{
    public class ProductCrud : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public ProductCrud(DbTeste dbTest)
        {
            _serviceProvide = dbTest.ServiceProvider;
        }

        [Fact]
        public async Task E_Possivel_Realizar_CRUD_Product()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                ProductImplementation _repositorio = new ProductImplementation(context);

                // Create
                ProductEntity _entity = new ProductEntity
                {
                    Code = Faker.RandomNumber.Next(),
                    Description = Faker.Company.Name()
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Code, _registroCriado.Code);
                Assert.Equal(_entity.Description, _registroCriado.Description);
                Assert.False(_registroCriado.Id == Guid.Empty);

                //Read
                var _registroEncontrado = await _repositorio.SelectAsync(_registroCriado.Code);
                Assert.Equal(_registroCriado.Code, _registroEncontrado.Code);
                Assert.False(_registroEncontrado.Id == Guid.Empty);

                //GetAll

                // ProductEntity _entity2 = new ProductEntity
                // {
                //     Code = Faker.RandomNumber.Next(),
                //     Description = Faker.Company.Name()
                // };
                // var _registroCriado2 = await _repositorio.InsertAsync(_entity);
                // var _resultadoTodos = await _repositorio.SelectAsync();

                // Assert.Contains(_resultadoTodos, resultado => resultado.Id == _registroCriado.Id);
                // Assert.Contains(_resultadoTodos, resultado => resultado.Id == _registroCriado2.Id);



                // // Update
                // _registroCriado.DateExpiry = Faker.DateOfBirth.Next();
                // _registroCriado.DateFabrication = Faker.DateOfBirth.Next();
                // _registroCriado.SupplierCnpj = Faker.RandomNumber.Next();
                // _registroCriado.SupplierCode = Faker.RandomNumber.Next();

                // var _registroAtualizado = await _repositorio.UpdateAsync(_registroCriado);

                // Assert.Equal(_registroCriado.DateExpiry, _registroAtualizado.DateExpiry);
                // Assert.Equal(_registroCriado.DateFabrication, _registroAtualizado.DateFabrication);
                // Assert.Equal(_registroCriado.SupplierCnpj, _registroAtualizado.SupplierCnpj);
                // Assert.Equal(_registroCriado.SupplierCode, _registroAtualizado.SupplierCode);

                // // Delete

                // var _registroDeletado = await _repositorio.DeleteAsync(_registroAtualizado.Id);
                // Assert.Equal(_registroDeletado.Status, StatusEnum.Inativo);
            }
        }
    }
}
