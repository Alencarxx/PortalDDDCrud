using System.Data.Entity.Migrations;
using PS.PostalBeneficiario.Infra.Dado.Contexto;

namespace PS.PostalBeneficiario.Infra.Dado.Migracoes
{
    internal sealed class Configuracao : DbMigrationsConfiguration<PostalBeneficiarioContext>
    {
        public Configuracao()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PostalBeneficiarioContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
