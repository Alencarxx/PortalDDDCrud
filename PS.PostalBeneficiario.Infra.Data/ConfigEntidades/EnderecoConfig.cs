using System.Data.Entity.ModelConfiguration;
using PS.PostalBeneficiario.Dominio.Entidades;

namespace PS.PostalBeneficiario.Infra.Dado.ConfigEntidades
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.EnderecoId);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8);

            Property(e => e.Complemento)
                .HasMaxLength(100);

            //HasOptional()
            HasRequired(e => e.Beneficiario)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.BeneficiarioId);

            ToTable("Enderecos");
        }
    }
}
