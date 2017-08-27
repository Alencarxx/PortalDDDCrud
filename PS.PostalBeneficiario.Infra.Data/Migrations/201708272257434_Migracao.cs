namespace PS.PostalBeneficiario.Infra.Dado.Migracoes
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beneficiarios",
                c => new
                    {
                        BeneficiarioId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 11, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BeneficiarioId)
                .Index(t => t.CPF, unique: true);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        EnderecoId = c.Guid(nullable: false),
                        Logradouro = c.String(nullable: false, maxLength: 150, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 100, unicode: false),
                        Complemento = c.String(maxLength: 100, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        CEP = c.String(nullable: false, maxLength: 8, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Estado = c.String(maxLength: 100, unicode: false),
                        BeneficiarioId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Beneficiarios", t => t.BeneficiarioId)
                .Index(t => t.BeneficiarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enderecos", "BeneficiarioId", "dbo.Beneficiarios");
            DropIndex("dbo.Enderecos", new[] { "BeneficiarioId" });
            DropIndex("dbo.Beneficiarios", new[] { "CPF" });
            DropTable("dbo.Enderecos");
            DropTable("dbo.Beneficiarios");
        }
    }
}
