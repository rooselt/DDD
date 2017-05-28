using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Sisacon.Domain.Enuns.AccountType;

namespace Sisacon.UI.ViewModels
{
    public class BankDetailsViewModel : BaseViewModel
    {
        [MaxLength(50)]
        public string Bank { get; set; }
        [MaxLength(10)]
        public string AccountNumber { get; set; }
        [MaxLength(10)]
        public string Agency { get; set; }
        public eAccountType eTipoConta { get; set; }
    }
}