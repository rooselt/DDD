using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.ValueObjects
{
    public class Address : BaseEntity
    {
        #region Properties

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        #endregion

        #region Constants

        public const int MAX_LENGTH_CEP = 9;
        public const int MAX_LENGTH_LOGRADOURO = 50;
        public const int MAX_LENGTH_COMPLEMENTO = 50;
        public const int MAX_LENGTH_BAIRRO = 50;
        public const int MAX_LENGTH_CIDADE = 30;
        public const int MAX_LENGTH_ESTADO = 20;

        #endregion
    }
}
