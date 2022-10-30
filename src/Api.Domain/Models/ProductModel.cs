using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Utils.Enums;

namespace Api.Domain.Models
{
    public class ProductModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private long _code;
        public long Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private StatusEnum _statusEnum;
        public StatusEnum Status
        {
            get { return _statusEnum; }
            set { _statusEnum = value; }
        }


        private DateTime _dateFabrication;
        public DateTime DateFabrication
        {
            get { return _dateFabrication; }
            set { _dateFabrication = value; }
        }

        private DateTime _dateExpiry;
        public DateTime DateExpiry
        {
            get { return _dateExpiry; }
            set { _dateExpiry = value; }
        }

        private long _supplierCode;
        public long SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }


        private string _supplierDescription;
        public string SupplierDescription
        {
            get { return _supplierDescription; }
            set { _supplierDescription = value; }
        }

        private long _supplierCnpj;
        public long SupplierCnpj
        {
            get { return _supplierCnpj; }
            set { _supplierCnpj = value; }
        }

        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set
            {
                _updateAt = value == null ? DateTime.UtcNow : value;
            }
        }


    }
}
