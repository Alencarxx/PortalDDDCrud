using System.Reflection;
using System.Web.Mvc;
using PS.PostalBeneficiario.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using PS.PostalBeneficiario.UI.MVC.App_Start;
using PS.PostalBeneficiario.Aplicacao.Interfaces;
using PS.PostalBeneficiario.Aplicacao;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace PS.PostalBeneficiario.UI.MVC.App_Start
{
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Options.EnableDynamicAssemblyCompilation = false;

            InitializeContainer(container);           

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}