using Sisacon.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {
        [Required]
        public string DefaultPage { get; set; }
        [Required]
        public bool CodAutoClient { get; set; }
        [Required]
        public bool CodAutoProvider { get; set; }
        [Required]
        public bool CodAutoMaterial { get; set; }
        [Required]
        public bool CodAutoProduct { get; set; }
        [Required]
        public bool CodAutoEstimate { get; set; }
        [Required]
        public bool CodAutoRequest { get; set; }
        [Required]
        public bool CodAutoEquipment { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}