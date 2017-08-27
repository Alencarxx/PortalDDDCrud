using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using PS.PostalBeneficiario.Dominio.Entidades;

namespace PS.PostalBeneficiario.Infra.Dado.ConfigEntidades
{
    public class BeneficiarioConfig : EntityTypeConfiguration<Beneficiario>
    {
        public BeneficiarioConfig()
        {
            HasKey(c => c.BeneficiarioId);
            //HasKey(c => new {c.BeneficiarioId, c.CPF});

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Ignore(c => c.ValidationResult);

            ToTable("Beneficiarios");
        }
    }
}
