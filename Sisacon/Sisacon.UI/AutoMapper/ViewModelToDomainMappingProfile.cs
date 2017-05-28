using AutoMapper;
using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using Sisacon.UI.ViewModels;

namespace Sisacon.UI.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMapping"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Configuration, ConfigurationViewModel>();
            CreateMap<Address, AddressViewModel>();
            CreateMap<Contact, ContactViewModel>();
            CreateMap<OccupationArea, OccupationAreaViewModel>();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<Client, ClientViewModel>();
            CreateMap<Equipment, EquipmentViewModel>();
            CreateMap<Provider, ProviderViewModel>();
            CreateMap<BankDetails, BankDetailsViewModel>();
            CreateMap<MaterialCategory, MaterialCategoryViewModel>();
            CreateMap<Material, MaterialViewModel>();
            CreateMap<PriceResearch, PriceResearchViewModel>();
            CreateMap<CostCategory, CostCategoryViewModel>();
            CreateMap<CostConfiguration, CostCategoryViewModel>();
            CreateMap<Cost, CostViewModel>();
            CreateMap<FixedCost, FixedCostViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}