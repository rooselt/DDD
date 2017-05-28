using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sisacon.UI.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        [MaxLength(10)]
        public string LandLine { get; set; }
        [MaxLength(11)]
        public string CellPhone { get; set; }
        [MaxLength(254)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string UrlSite { get; set; }
    }
}