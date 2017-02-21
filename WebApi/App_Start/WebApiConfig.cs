namespace WebApi
{
    using DependencyResolvers;
    using Microsoft.Practices.Unity;
    using System.Web.Http;
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<Model.Repositories.IDepartmentRepository, DataAccess.EF.Repositories.DepartmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<Model.Repositories.IUserRepository, DataAccess.EF.Repositories.UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<Model.IUnitOfWork, DataAccess.EF.UnitOfWork>(new HierarchicalLifetimeManager());
            //container.RegisterTypes(
            //    AllClasses.FromLoadedAssemblies(),
            //    WithMappings.FromMatchingInterface,
            //    WithName.TypeName,
            //    WithLifetime.Hierarchical
            //    );
            config.DependencyResolver = new UnityDependencyResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DepartmentApi",
                routeTemplate: "api2/department/{id}",
                defaults: new { controller = "Department", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: "api1/user/{id}",
                defaults: new { controller = "User", id = RouteParameter.Optional }
            );
        }
    }
}
