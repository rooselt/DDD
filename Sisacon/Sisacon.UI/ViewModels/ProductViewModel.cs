using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(10)]
        public string CodProduct { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Info { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public decimal ProfitPercentage { get; set; }
        [Required]
        public int HoursToProduce { get; set; }
        [Required]
        public int MinutesToProduce { get; set; }
        [Required]
        public decimal CostPerHour { get; set; }
        [Required]
        public decimal TotalCostMaterials { get; set; }
        public int UserId { get; set; }
        [Required]
        public virtual User User { get; set; }
        public virtual List<Material> ListMaterial { get; set; }
        public virtual List<ProductImages> ListProductImages { get; set; }
    }
}