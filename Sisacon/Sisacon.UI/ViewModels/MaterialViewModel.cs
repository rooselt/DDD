using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class MaterialViewModel : BaseViewModel
    {
        [MaxLength(10)]
        public string CodMaterial { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [MaxLength(250)]
        public string Note { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public virtual MaterialCategory Category { get; set; }
        public virtual List<PriceResearch> ListPriceResearch { get; set; }
        [Required]
        public virtual User User { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}