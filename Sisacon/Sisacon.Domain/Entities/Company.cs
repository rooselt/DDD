using Sisacon.Domain.ValueObjects;
using static Sisacon.Domain.Enuns.PersonType;

namespace Sisacon.Domain.Entities
{
    public class Company : BaseEntity
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
        public virtual OccupationArea OccupationArea { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual User User { get; set; }
    }
}
