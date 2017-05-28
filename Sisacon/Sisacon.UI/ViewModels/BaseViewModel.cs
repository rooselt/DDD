using System;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public abstract class BaseViewModel
    {
        [Required]
        public int Id { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? ExclusionDate { get; set; }
    }
}