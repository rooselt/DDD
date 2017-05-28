using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sisacon.UI.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        [MaxLength(9)]
        public string Cep { get; set; }
        [MaxLength(50)]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        [MaxLength(50)]
        public string Complemento { get; set; }
        [MaxLength(50)]
        public string Bairro { get; set; }
        [MaxLength(30)]
        public string Cidade { get; set; }
        [MaxLength(20)]
        public string Estado { get; set; }
    }
}