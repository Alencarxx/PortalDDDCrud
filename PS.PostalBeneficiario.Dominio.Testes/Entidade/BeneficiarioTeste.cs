using System;
using System.Linq;
using PS.PostalBeneficiario.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PS.PostalBeneficiario.Dominio.Testes.Entidade
{
    [TestClass]
    public class BeneficiarioTeste
    {
        // boneco
        public Beneficiario Beneficiario { get; set; }

        [TestMethod]
        public void BeneficiarioConsistente_Valid_True()
        {
            Beneficiario = new Beneficiario
            {
                CPF = "30390600822",
                DataNascimento = new DateTime(1982, 01, 01),
                Email = "bene@bene.com.br"
            };

            //Assert.IsTrue(Beneficiario.IsValid());
        }

        [TestMethod]
        public void BeneficiarioConsistente_Valid_False()
        {
            Beneficiario = new Beneficiario
            {
                CPF = "30390600821",
                DataNascimento = new DateTime(2005, 01, 01),
                Email = "bene@bene.com.br"
            };

            //Assert.IsFalse(Beneficiario.IsValid());
           // Assert.IsTrue(Beneficiario.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido."));
            //Assert.IsTrue(Beneficiario.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um e-mail inválido."));            
        }
    }
}
