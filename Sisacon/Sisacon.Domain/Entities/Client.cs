using Helpers;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.Enuns.PersonType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Domain.Entities
{
    public class Client : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_CPF = 11;
        public const int MAX_LENGTH_CNPJ = 14;
        public const int MAX_LENGTH_RG = 10;
        public const int MAX_LENGTH_CLIENT_NAME = 50;
        public const int MAX_LENGTH_FANTASY_NAME = 50;
        public const int MAX_LENGTH_SOCIALREASON = 50;
        public const int MAX_LENGTH_NOTE = 250;

        #endregion

        #region Properties

        public string CodCliente { get; set; }
        public ePersonType ePersonType { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Rg { get; set; }
        public string ClientName { get; set; }
        public DateTime? Birthday { get; set; }
        public eSex eSex { get; set; }
        public string FantasyName { get; set; }
        public string SocialReasonName { get; set; }
        public int? IdAddress { get; set; }
        public int? IdContact { get; set; }
        public int IdUser { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual User User { get; set; }
        public bool SendAutomaticMsg { get; set; }
        public bool AddBirthdayToCalendar { get; set; }
        public string Note { get; set; }

        #endregion

        #region Methods

        public bool IsValid()
        {
            var valid = true;

            if (ePersonType == ePersonType.Fisica && (string.IsNullOrEmpty(Cpf) || Cpf.Length < MAX_LENGTH_CPF))
            {
                valid = false;
            }

            if (ePersonType == ePersonType.Juridica && (string.IsNullOrEmpty(Cnpj) || Cnpj.Length < MAX_LENGTH_CNPJ))
            {
                valid = false;
            }

            return valid;
        }

        public void GenereteCode()
        {
            CodCliente = string.Format("CLT{0}", Utils.GereneteRandomCode());
        }

        public bool ValidatePendencesBeforeDelete()
        {
            var valid = true;

            //implementar quando necessario

            return valid;
        }

        #endregion
    }
}
