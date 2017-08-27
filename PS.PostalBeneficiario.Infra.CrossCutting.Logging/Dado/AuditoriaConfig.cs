using System.Data.Entity.ModelConfiguration;
using PS.PostalBeneficiario.Infra.CrossCutting.Logging.Modelo;

namespace PS.PostalBeneficiario.Infra.CrossCutting.Logging.Dado
{
    public class AuditoriaConfig : EntityTypeConfiguration<Auditoria>
    {
        public AuditoriaConfig()
        {
            HasKey(a => a.LogId);

            Property(a => a.Sistema)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(a => a.Acao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(1000);

            Property(a => a.IP)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            Property(a => a.UserId)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            ToTable("LogAuditoria");
        }
    }
}
