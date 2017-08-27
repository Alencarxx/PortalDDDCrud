using System.Linq;
using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Dominio.Interfaces.Repositorio;
using PS.PostalBeneficiario.Dominio.Validacoes.Beneficiarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace PS.PostalBeneficiario.Dominio.Testes.Validacao
{
    [TestClass]
    public class BeneficiarioAptoParaCadastroTeste
    {
        public Beneficiario Beneficiario { get; set; }

        [TestMethod]
        public void ClienteApto_Validation_True()
        {
            Beneficiario = new Beneficiario()
            {
                CPF = "30390600822",
                Email = "edu@edu.com.br"
            };

            Beneficiario.Enderecos.Add(new Endereco());

            var stubRepo = MockRepository.GenerateStub<IBeneficiarioRepositorio>();
            stubRepo.Stub(s => s.ObterPorEmail(Beneficiario.Email)).Return(null);
            stubRepo.Stub(s => s.ObterPorCpf(Beneficiario.CPF)).Return(null);

            var beValidation = new BeneficiarioAptoParaCadastroValidacoes(stubRepo);
            Assert.IsTrue(beValidation.Validate(Beneficiario).IsValid);
        }

        [TestMethod]
        public void ClienteApto_Validation_False()
        {
            Beneficiario = new Beneficiario()
            {
                CPF = "30390600822",
                Email = "edu@edu.com.br"
            };

            var stubRepo = MockRepository.GenerateStub<IBeneficiarioRepositorio>();
            stubRepo.Stub(s => s.ObterPorEmail(Beneficiario.Email)).Return(Beneficiario);
            stubRepo.Stub(s => s.ObterPorCpf(Beneficiario.CPF)).Return(Beneficiario);

            var cliValidation = new BeneficiarioAptoParaCadastroValidacoes(stubRepo);
            var result = cliValidation.Validate(Beneficiario);

            Assert.IsFalse(cliValidation.Validate(Beneficiario).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "CPF já cadastrado! Esqueceu sua senha?"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "E-mail já cadastrado! Esqueceu sua senha?"));
        }
    }
}
