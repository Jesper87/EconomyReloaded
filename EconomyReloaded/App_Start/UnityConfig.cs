using System;
using EconomyReloaded.Core.Database;
using EconomyReloaded.Core.Factory.Economy;
using EconomyReloaded.Core.Factory.User;
using EconomyReloaded.Core.Repositories.Economy;
using EconomyReloaded.Core.Repositories.User;
using EconomyReloaded.Services.Services.Economy;
using EconomyReloaded.Services.Services.User;
using Microsoft.Practices.Unity;

namespace EconomyReloaded
{
  /// <summary>
  /// Specifies the Unity configuration for the main container.
  /// </summary>
  public class UnityConfig
  {
    #region Unity Container
    private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
    {
      var container = new UnityContainer();
      RegisterTypes(container);
      return container;
    });

    /// <summary>
    /// Gets the configured Unity container.
    /// </summary>
    public static IUnityContainer GetConfiguredContainer()
    {
      return container.Value;
    }
    #endregion

    /// <summary>Registers the type mappings with the Unity container.</summary>
    /// <param name="container">The unity container to configure.</param>
    /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
    /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
    public static void RegisterTypes(IUnityContainer container)
    {
      // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
      // container.LoadConfiguration();

      // TODO: Register your types here

      container.RegisterType<IUserRepository, UserRepository>()
      .RegisterType<IUserFactory, UserFactory>()
      .RegisterType<IUserService, UserService>()
      .RegisterType<IReceiptService, ReceiptService>()
      .RegisterType<IReceiptFactory, ReceiptFactory>()
      .RegisterType<IReceiptRepository, ReceiptRepository>()
      .RegisterType<IDatabaseConnection, DatabaseConnection>();



      // container.RegisterType<IProductRepository, ProductRepository>();
    }
  }
}
