using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sisacon.UI.ViewModels
{
    public class CostConfigurationViewModel : BaseViewModel
    {
        [Required]
        public decimal MaxValue { get; set; }
        [Required]
        public bool IncludDevaluationOfEquipment { get; set; }
        public int UserId { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}