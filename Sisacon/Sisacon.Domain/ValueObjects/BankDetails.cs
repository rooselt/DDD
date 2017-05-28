using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.Enuns.AccountType;

namespace Sisacon.Domain.ValueObjects
{
    public class BankDetails : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_BANK = 50;
        public const int MAX_LENGTH_ACCOUNTNUMBER = 10;
        public const int MAX_LENGTH_AGENCY = 10;

        #endregion

        #region Propeties

        public string Bank { get; set; }
        public string AccountNumber { get; set; }
        public string Agency { get; set; }
        public eAccountType eTipoConta { get; set; }

        #endregion
    }
}
