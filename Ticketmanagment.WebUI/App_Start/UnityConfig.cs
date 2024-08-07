using System;
using Ticketmanagment.DataAccess.Sql;
using Ticketmanagment.Services;
using TicketManagment.Core.Contracts;
using TicketManagment.Core.Models;
using Unity;

namespace Ticketmanagment.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IRepository<Users>, SQLRepository<Users>>();
            container.RegisterType<IRepository<UserRole>, SQLRepository<UserRole>>();
            container.RegisterType<IRepository<Timesheet>, SQLRepository<Timesheet>>();
            container.RegisterType<IRepository<Ticket>, SQLRepository<Ticket>>();
            container.RegisterType<IRepository<Roles>, SQLRepository<Roles>>();
            container.RegisterType<IRepository<Comment>, SQLRepository<Comment>>();
            container.RegisterType<IRepository<CommonLookup>, SQLRepository<CommonLookup>>();

            
            container.RegisterType<IUserService, UserServices>();
            container.RegisterType<IRoleService, RoleServices>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<ITicketService, TicketService>();
            container.RegisterType<ICommonLookup, CommonLookupService>();


        }
    }
}