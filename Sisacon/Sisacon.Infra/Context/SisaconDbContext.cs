using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using Sisacon.Infra.Mapping;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Sisacon.Repositories.Context
{
    public class SisaconDbContext : DbContext
    {
        public SisaconDbContext()
            : base("SisaconConnectionString")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Configuration> Config { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<OccupationArea> OccupationArea { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<BankDetails> BankDetails { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<MaterialCategory> MaterialCategory { get; set; }
        public DbSet<PriceResearch> PriceResearch { get; set; }
        public DbSet<CostCategory> CostCategory { get; set; }
        public DbSet<CostConfiguration> CostConfiguration { get; set; }
        public DbSet<Cost> Cost { get; set; }
        public DbSet<FixedCost> FixedCost { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new LogMap());
            modelBuilder.Configurations.Add(new ConfigurationMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new NotificationMap());
            modelBuilder.Configurations.Add(new OccupationAreaMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new EquipmentMap());
            modelBuilder.Configurations.Add(new ProviderMap());
            modelBuilder.Configurations.Add(new BankDetailsMap());
            modelBuilder.Configurations.Add(new MaterialMap());
            modelBuilder.Configurations.Add(new MaterialCategoryMap());
            modelBuilder.Configurations.Add(new PriceResearchMap());
            modelBuilder.Configurations.Add(new CostCategoryMap());
            modelBuilder.Configurations.Add(new CostConfigurationMap());
            modelBuilder.Configurations.Add(new CostMap());
            modelBuilder.Configurations.Add(new FixedCostMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductImagesMap());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegistrationDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegistrationDate").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
