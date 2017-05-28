using Helpers;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.Enuns.PersonType;

namespace Sisacon.Domain.Entities
{
    public class Provider : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_CNPJ = 14;
        public const int MAX_LENGTH_SOCIAOREASON = 50;
        public const int MAX_LENGTH_FANTASYNAME = 50;
        public const int MAX_LENGTH_NOTE = 250;

        #endregion

        #region Propeties

        public string CodProvider { get; set; }
        public string Cnpj { get; set; }
        public string SocialReasonName { get; set; }
        public string FantasyName { get; set; }
        public string Note { get; set; }
        public int? IdAddress { get; set; }
        public int? IdContact { get; set; }
        public int? IdBankDetails { get; set; }
        public int IdUser { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual BankDetails BankDetails { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Methods

        public bool isValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(Cnpj) || Cnpj.Length < MAX_LENGTH_CNPJ)
            {
                valid = false;
            }

            return valid;
        }

        public void genereteCode()
        {
            CodProvider = string.Format("FRN{0}", Utils.GereneteRandomCode());
        }

        #endregion
    }
}
