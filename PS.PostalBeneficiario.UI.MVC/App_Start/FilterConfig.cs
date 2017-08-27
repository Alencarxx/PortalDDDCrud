using PS.PostalBeneficiario.Infra.CrossCutting.MvcFlte;
using System.Web.Mvc;

namespace PS.PostalBeneficiario.UI.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, SimpleInjector.Container container)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(container.GetInstance<GlobalFilterTool>());
        }
    }
}
