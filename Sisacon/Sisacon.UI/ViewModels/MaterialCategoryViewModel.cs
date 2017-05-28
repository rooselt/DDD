using Sisacon.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class MaterialCategoryViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        public int IdUser { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}