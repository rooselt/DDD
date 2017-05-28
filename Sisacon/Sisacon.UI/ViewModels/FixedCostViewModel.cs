using Sisacon.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class FixedCostViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public decimal Value { get; set; }
        public int CostCategoryId { get; set; }
        public int CostId { get; set; }
        [Required]
        public virtual CostCategory CostCategory { get; set; }
    }
}