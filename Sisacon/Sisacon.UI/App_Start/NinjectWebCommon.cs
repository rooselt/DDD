[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Sisacon.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Sisacon.UI.App_Start.NinjectWebCommon), "Stop")]

namespace Sisacon.UI.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Sisacon.Application;
    using Sisacon.Application.Interfaces;
    using Sisacon.Domain.Interfaces;
    using Sisacon.Domain.Interfaces.Repositories;
    using Sisacon.Domain.Interfaces.Services;
    using Sisacon.Domain.Services;
    using Sisacon.Infra.Repositories;
    using System;
    using System.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //APPLICATION
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IUserAppService>().To<UserAppService>();
            kernel.Bind<IConfigurationAppService>().To<ConfigurationAppService>();
            kernel.Bind<INotificationAppService>().To<NotificationAppService>();
            kernel.Bind<ICrudMsgFormater>().To<CrudMsgFormater>();
            kernel.Bind<ILogAppService>().To<LogAppService>();
            kernel.Bind<ICompanyAppService>().To<CompanyAppService>();
            kernel.Bind<IClientAppService>().To<ClientAppService>();
            kernel.Bind<IEquipmentAppService>().To<EquipmentAppService>();
            kernel.Bind<IProviderAppService>().To<ProviderAppService>();
            kernel.Bind<IMaterialCategoryAppService>().To<MaterialCategoryAppService>();
            kernel.Bind<IMaterialAppService>().To<MaterialAppService>();
            kernel.Bind<IPriceResearchAppService>().To<PriceResearchAppService>();
            kernel.Bind<ICostCategoryAppService>().To<CostCategoryAppService>();
            kernel.Bind<ICostConfigurationAppService>().To<CostConfigurationAppService>();
            kernel.Bind<ICostAppService>().To<CostAppService>();
            kernel.Bind<IFixedCostAppService>().To<FixedCostAppService>();
            kernel.Bind<IProductAppService>().To<ProductAppService>();

            //SERVICE
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IConfigurationService>().To<ConfigurationService>();
            kernel.Bind<INotificationService>().To<NotificationService>();
            kernel.Bind<ILogService>().To<LogService>();
            kernel.Bind<ICompanyService>().To<CompanyService>();
            kernel.Bind<IOccupationAreaService>().To<OccupationAreaService>();
            kernel.Bind<IClientService>().To<ClientService>();
            kernel.Bind<IEquipmentService>().To<EquipmentService>();
            kernel.Bind<IProviderService>().To<ProviderService>();
            kernel.Bind<IMaterialCategoryService>().To<MaterialCategoryService>();
            kernel.Bind<IMaterialService>().To<MaterialService>();
            kernel.Bind<IPriceResearchService>().To<PriceResearchService>();
            kernel.Bind<ICostCategoryService>().To<CostCategoryService>();
            kernel.Bind<ICostConfigurationService>().To<CostConfigurationService>();
            kernel.Bind<ICostService>().To<CostService>();
            kernel.Bind<IFixedCostService>().To<FixedCostService>();
            kernel.Bind<IProductService>().To<ProductService>();

            //REPOSITORIES
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IConfigurationRepository>().To<ConfigurationRepository>();
            kernel.Bind<INotificationRepository>().To<NotificationRepository>();
            kernel.Bind<ILogRepository>().To<LogRepository>();
            kernel.Bind<ICompanyRepository>().To<CompanyRepository>();
            kernel.Bind<IOccupationAreaRepository>().To<OccupationAreaRepository>();
            kernel.Bind<IClientRepository>().To<ClientRepository>();
            kernel.Bind<IEquipmentRepository>().To<EquipmentRepositoy>();
            kernel.Bind<IProviderRepository>().To<ProviderRepository>();
            kernel.Bind<IMaterialCategoryRepository>().To<MaterialCategoryRepository>();
            kernel.Bind<IMaterialRepository>().To<MaterialRepository>();
            kernel.Bind<IPriceResearchRepository>().To<PriceResearchRepository>();
            kernel.Bind<ICostCategoryRepository>().To<CostCategoryRepository>();
            kernel.Bind<ICostConfigurationRepository>().To<CostConfigurationRepository>();
            kernel.Bind<ICostRepository>().To<CostRepository>();
            kernel.Bind<IFixedCostRepository>().To<FixedCostRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}
