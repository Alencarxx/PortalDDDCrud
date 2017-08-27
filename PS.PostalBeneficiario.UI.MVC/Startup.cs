using PS.PostalBeneficiario.UI.MVC;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace PS.PostalBeneficiario.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            ConfigureAuth(app);
        }       
    }
}