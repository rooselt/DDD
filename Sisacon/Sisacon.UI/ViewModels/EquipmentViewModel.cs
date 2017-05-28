using Sisacon.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class EquipmentViewModel : BaseViewModel
    {
        public string CodEquipment { get; set; }
        [MaxLength(50)]
        public string SerialNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string Desc { get; set; }
        [Required]
        public DateTime AcquisitionDate { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        [MaxLength(50)]
        public string Manufacturer { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public int LifeSpan { get; set; }
        [MaxLength(50)]
        public string NameTechnicalAssistance { get; set; }
        [MaxLength(50)]
        public string PhoneTechnicalAssistance { get; set; }
        public int IdUser { get; set; }
        [Required]
        public User User { get; set; }

    }
}