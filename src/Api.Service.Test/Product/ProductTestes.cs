using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Product;
using Api.Domain.Utils.Enums;

namespace Api.Service.Test.Product
{
    public class ProductTestes
    {
        public static Guid IdProduct { get; set; }
        public static long Code { get; set; }
        public static string Description { get; set; }
        public static StatusEnum Status { get; set; }

        public static DateTime? DateFabrication { get; set; }

        public static DateTime? DateExpiry { get; set; }

        public static long? SupplierCode { get; set; }

        public static string SupplierDescription { get; set; }

        public static long? SupplierCnpj { get; set; }



        public static string DescriptionAlterado { get; set; }

        public static DateTime? DateFabricationAlterado { get; set; }

        public static DateTime? DateExpiryAlterado { get; set; }

        public static long? SupplierCodeAlterado { get; set; }

        public static string SupplierDescriptionAlterado { get; set; }

        public static long? SupplierCnpjAlterado { get; set; }




        public List<ProductDto> listaProductDto = new List<ProductDto>();

        public ProductDto productDto;

        public ProductDtoCreate productDtoCreate;
        public ProductDtoCreateResult productDtoCreateResult;

        public ProductDtoUpdate productDtoUpdate;

        public ProductDtoUpdateResult productDtoUpdateResult;

        public ProductDtoDelete productDtoDelete;

        public ProductTestes()
        {
            IdProduct = Guid.NewGuid();
            Code = Faker.RandomNumber.Next();
            Description = Faker.Lorem.Sentence();
            Status = StatusEnum.Ativo;
            DateFabrication = Faker.DateOfBirth.Next();
            DateExpiry = Faker.DateOfBirth.Next();
            SupplierCode = Faker.RandomNumber.Next();
            SupplierDescription = Faker.Lorem.Sentence();
            SupplierCnpj = Faker.RandomNumber.Next();


            DescriptionAlterado = Faker.Lorem.Sentence();
            DateFabricationAlterado = Faker.DateOfBirth.Next();
            DateExpiryAlterado = Faker.DateOfBirth.Next();
            SupplierCodeAlterado = Faker.RandomNumber.Next();
            SupplierDescriptionAlterado = Faker.Lorem.Sentence();
            SupplierCnpjAlterado = Faker.RandomNumber.Next();


            for (int i = 0; i < 10; i++)
            {
                var dto = new ProductDto()
                {
                    Id = Guid.NewGuid(),
                    Code = Faker.RandomNumber.Next(),
                    Description = Faker.Lorem.Sentence(),
                    Status = StatusEnum.Ativo,
                    DateFabrication = Faker.DateOfBirth.Next(),
                    DateExpiry = Faker.DateOfBirth.Next(),
                    SupplierCode = Faker.RandomNumber.Next(),
                    SupplierDescription = Faker.Lorem.Sentence(),
                    SupplierCnpj = Faker.RandomNumber.Next()
                };
                listaProductDto.Add(dto);
            }

            productDto = new ProductDto
            {
                Id = IdProduct,
                Code = Code,
                Description = Description,
                Status = Status,
                DateFabrication = DateFabrication,
                DateExpiry = DateExpiry,
                SupplierCode = SupplierCode,
                SupplierDescription = SupplierDescription,
                SupplierCnpj = SupplierCnpj
            };

            productDtoCreate = new ProductDtoCreate
            {
                Id = IdProduct,
                Code = Code,
                Description = Description,
                Status = Status,
                DateFabrication = DateFabrication,
                DateExpiry = DateExpiry,
                SupplierCode = SupplierCode,
                SupplierDescription = SupplierDescription,
                SupplierCnpj = SupplierCnpj
            };

            productDtoCreateResult = new ProductDtoCreateResult
            {
                Id = IdProduct,
                Code = Code,
                Description = Description,
                Status = Status,
                DateFabrication = DateFabrication,
                DateExpiry = DateExpiry,
                SupplierCode = SupplierCode,
                SupplierDescription = SupplierDescription,
                SupplierCnpj = SupplierCnpj
            };

            productDtoUpdate = new ProductDtoUpdate
            {
                Id = IdProduct,
                Description = Description,
                DateFabrication = DateFabrication,
                DateExpiry = DateExpiry,
                SupplierCode = SupplierCode,
                SupplierDescription = SupplierDescription,
                SupplierCnpj = SupplierCnpj
            };

            productDtoUpdateResult = new ProductDtoUpdateResult
            {
                Id = IdProduct,
                Description = Description,
                DateFabrication = DateFabrication,
                DateExpiry = DateExpiry,
                SupplierCode = SupplierCode,
                SupplierDescription = SupplierDescription,
                SupplierCnpj = SupplierCnpj
            };

            productDtoDelete = new ProductDtoDelete
            {
                Id = IdProduct,
                Code = Code,
                Status = Status
            };



        }
    }
}

