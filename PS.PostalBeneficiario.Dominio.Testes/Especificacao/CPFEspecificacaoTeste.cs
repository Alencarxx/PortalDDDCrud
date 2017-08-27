using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Dominio.Especificacoes.Beneficiarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PS.PostalBeneficiario.Dominio.Testes.Especificacao
{
    [TestClass]
    public class CPFEspecificacaoTeste
    {
        public Beneficiario Beneficiario { get; set; }

        [TestMethod]
        public void CPF_Valido_True()
        {
            Beneficiario = new Beneficiario()
            {
                CPF = "30390600822"
            };

            var cpf = new BeneficiarioDeveTerCpfValidoEspecificacoes();
            Assert.IsTrue(cpf.IsSatisfiedBy(Beneficiario));
        }

        [TestMethod]
        public void CPF_Valido_False()
        {
            Beneficiario = new Beneficiario()
            {
                CPF = "30390600821"
            };

            var cpf = new BeneficiarioDeveTerCpfValidoEspecificacoes();
            Assert.IsFalse(cpf.IsSatisfiedBy(Beneficiario));
        }
    }
}
