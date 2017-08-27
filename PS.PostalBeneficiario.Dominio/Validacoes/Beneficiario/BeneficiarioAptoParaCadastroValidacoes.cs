using DomainValidation.Validation;
using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Dominio.Especificacoes.Beneficiarios;
using PS.PostalBeneficiario.Dominio.Interfaces.Repositorio;

namespace PS.PostalBeneficiario.Dominio.Validacoes.Beneficiarios
{
    public class BeneficiarioAptoParaCadastroValidacoes : Validator<Beneficiario>
    {
        public BeneficiarioAptoParaCadastroValidacoes(IBeneficiarioRepositorio beneficiarioRepositorio)
        {
            var cpfDuplicado = new BeneficiarioDevePossuirCPFUnicoEspecificacoes(beneficiarioRepositorio);
            var emailDuplicado = new BeneficiarioDevePossuirEmailUnicoEspecificacoes(beneficiarioRepositorio);
            var beneficiarioEndereco = new BeneficiarioDeveTerUmEnderecoEspecificacoes();

            base.Add("cpfDuplicado", new Rule<Beneficiario>(cpfDuplicado, "CPF já cadastrado! Esqueceu sua senha?"));
            base.Add("emailDuplicado", new Rule<Beneficiario>(emailDuplicado, "E-mail já cadastrado! Esqueceu sua senha?"));
            base.Add("beneficiarioEndereco", new Rule<Beneficiario>(beneficiarioEndereco, "Beneficiário não informou endereço"));
        }
    }
}
