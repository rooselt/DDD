using Sisacon.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class PriceResearchViewModel : BaseViewModel
    {
        [Required()]
        public decimal Price { get; set; }
        public int ProviderId { get; set; }
        public int MaterialId { get; set; }
        [Required()]
        public virtual Material Material { get; set; }
        [Required()]
        public virtual Provider Provider { get; set; }
        [Required()]
        public DateTime SearchDate { get; set; }
    }
}