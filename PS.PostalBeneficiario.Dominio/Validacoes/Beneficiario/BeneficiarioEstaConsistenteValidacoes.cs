using DomainValidation.Validation;
using PS.PostalBeneficiario.Dominio.Especificacoes.Beneficiarios;
using PS.PostalBeneficiario.Dominio.Entidades;

namespace PS.PostalBeneficiario.Dominio.Validacoes.Beneficiarios
{
    public class BeneficiarioEstaConsistenteValidacoes : Validator<Beneficiario>
    {
        public BeneficiarioEstaConsistenteValidacoes()
        {
            var CPFBeneficiario = new BeneficiarioDeveTerCpfValidoEspecificacoes();
            var beneficiarioEmail = new BeneficiarioDeveTerEmailValidoEspecificacoes();            

            base.Add("CPFBeneficiario", new Rule<Beneficiario>(CPFBeneficiario, "Beneficiário informou um CPF inválido."));
            base.Add("beneficiarioEmail", new Rule<Beneficiario>(beneficiarioEmail, "Beneficiário informou um e-mail inválido."));
        }
    }
}
