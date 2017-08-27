using System.Data.Entity.Migrations;
using PS.PostalBeneficiario.Infra.CrossCutting.Logging.Dado;

namespace PS.PostalBeneficiario.Infra.CrossCutting.Logging.Migracao
{
    internal sealed class Configuracao : DbMigrationsConfiguration<LogginContexto>
    {
        public Configuracao()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LogginContexto context)
        {

        }
    }
}
