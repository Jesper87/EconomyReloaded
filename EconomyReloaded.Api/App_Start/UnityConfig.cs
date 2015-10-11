using Microsoft.Practices.Unity;
using System.Web.Http;
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factory.Economy;
using EconomyReloaded.Core.Factory.User;
using EconomyReloaded.Core.Repositories.Economy;
using EconomyReloaded.Core.Repositories.User;
using EconomyReloaded.Services.Services.Economy;
using EconomyReloaded.Services.Services.User;
using Unity.WebApi;

namespace EconomyReloaded.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserFactory, UserFactory>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IDatabaseConnection, DatabaseConnection>();
            container.RegisterType<IReceiptRepository, ReceiptRepository>();
            container.RegisterType<IReceiptFactory, ReceiptFactory>();
            container.RegisterType<IReceiptService, ReceiptService>();
            
        }
    }
}