using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Utils.Enums;

namespace Api.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {

        [Required]
        public long Code { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public StatusEnum Status { get; set; }

        public DateTime? DateFabrication { get; set; }

        public DateTime? DateExpiry { get; set; }

        public long? SupplierCode { get; set; }

        public string SupplierDescription { get; set; }

        public long? SupplierCnpj { get; set; }


    }
}
