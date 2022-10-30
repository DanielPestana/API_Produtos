using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Utils.Enums;

namespace Api.Domain.Dtos.Product
{
    public class ProductDtoUpdateResult
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo código é obrigatório.")]
        public long Code { get; set; }

        [Required(ErrorMessage = "Campo descrição obrigatória.")]
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime? DateFabrication { get; set; }

        public DateTime? DateExpiry { get; set; }

        public long? SupplierCode { get; set; }

        public string SupplierDescription { get; set; }

        public long? SupplierCnpj { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
