using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sisacon.UI.ViewModels
{
    public class CostViewModel : BaseViewModel
    {
        [Required]
        public string ReferenceMonthText { get; set; }
        [Required]
        public int WorkedHours { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public decimal TotalFixedCost { get; set; }
        public decimal TotalDevaluationOfEquipment { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CostPerHour { get; set; }
        [Required]
        public bool Closed { get; set; }
        [Required]
        public bool Current { get; set; }
        public int UserId { get; set; }
        [Required]
        public virtual User User { get; set; }
        public virtual List<FixedCost> ListFixedCost { get; set; }
    }
}