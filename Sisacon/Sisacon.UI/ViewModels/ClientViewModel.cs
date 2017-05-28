using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Sisacon.Domain.Enuns.PersonType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.UI.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        
        [MaxLength(10)]
        public string CodCliente { get; set; }
        [Required]
        public ePersonType ePersonType { get; set; }
        [MaxLength(11)]
        public string Cpf { get; set; }
        [MaxLength(14)]
        public string Cnpj { get; set; }
        [MaxLength(10)]
        public string Rg { get; set; }
        [MaxLength(50)]
        public string ClientName { get; set; }
        public DateTime? Birthday { get; set; }
        public eSex eSex { get; set; }
        [MaxLength(50)]
        public string FantasyName { get; set; }
        [MaxLength(50)]
        public string SocialReasonName { get; set; }
        public int? IdAddress { get; set; }
        public int? IdContact { get; set; }
        public int IdUser { get; set; }
        public  Address Address { get; set; }
        public Contact Contact { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public bool SendAutomaticMsg { get; set; }
        [Required]
        public bool AddBirthdayToCalendar { get; set; }
        public string Note { get; set; }
    }
}