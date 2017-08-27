using System.Web.Http;
using PS.PostalBeneficiario.Aplicacao.AutoMapper;

namespace PS.PostalBeneficiario.Services.REST.BeneficiarioAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
