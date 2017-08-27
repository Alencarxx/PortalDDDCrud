using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Infra.Dado.ConfigEntidades;

namespace PS.PostalBeneficiario.Infra.Dado.Contexto
{
    public class PostalBeneficiarioContext : DbContext
    {
        public PostalBeneficiarioContext()
            : base("DefaultConnection")
        {

        }


        public DbSet<Beneficiario> Beneficiario { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new BeneficiarioConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

    }

    // Classe para trocar a ConnectionString do EF em tempo de execução.
    public static class ChangeDb
    {
        public static void ChangeConnection(this PostalBeneficiarioContext context, string cn)
        {
            context.Database.Connection.ConnectionString = cn;
        }
    }
}
