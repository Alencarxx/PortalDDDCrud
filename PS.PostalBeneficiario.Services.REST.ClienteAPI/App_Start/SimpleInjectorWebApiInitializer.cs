using System.Web.Http;
using PS.PostalBeneficiario.Services.REST.BeneficiarioAPI.App_Start;
using PS.PostalBeneficiario.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorWebApiInitializer), "Initialize")]

namespace PS.PostalBeneficiario.Services.REST.BeneficiarioAPI.App_Start
{
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            //container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}