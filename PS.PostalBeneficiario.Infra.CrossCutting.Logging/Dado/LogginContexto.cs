using System.Data.Common;
using System.Data.Entity;
using PS.PostalBeneficiario.Infra.CrossCutting.Logging.Modelo;

namespace PS.PostalBeneficiario.Infra.CrossCutting.Logging.Dado
{
    public class LogginContexto : DbContext
    {
        public LogginContexto()
            : base("DefaultConnection")
        {

        }

        public DbSet<Auditoria> LogAuditoria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuditoriaConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
