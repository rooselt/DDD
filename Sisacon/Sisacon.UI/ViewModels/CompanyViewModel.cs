using static Sisacon.Domain.Enuns.PersonType;

namespace Sisacon.UI.ViewModels
{
    public class CompanyViewModel : BaseViewModel
    {
        public ePersonType ePersonType { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public string SocialReasonName { get; set; }
        public string Slogan { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }

        //RELATIONSHIP
        public int? IdOccupationArea { get; set; }
        public int? IdAddress { get; set; }
        public int? IdContact { get; set; }
        public int IdUser { get; set; }
        public virtual OccupationAreaViewModel OccupationArea { get; set; }
        public virtual AddressViewModel Address { get; set; }
        public virtual ContactViewModel Contact { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}