using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Utils.Enums;

namespace Api.Domain.Dtos.Product
{
    public class ProductDtoDelete
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo código é obrigatório.")]
        public long Code { get; set; }
        public StatusEnum Status { get; set; }

    }
}
