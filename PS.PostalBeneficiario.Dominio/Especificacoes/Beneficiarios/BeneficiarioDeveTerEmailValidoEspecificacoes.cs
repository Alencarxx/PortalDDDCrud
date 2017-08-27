using DomainValidation.Interfaces.Specification;
using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Dominio.Validacoes.Documentos;

namespace PS.PostalBeneficiario.Dominio.Especificacoes.Beneficiarios
{
    public class BeneficiarioDeveTerEmailValidoEspecificacoes : ISpecification<Beneficiario>
    {
        public bool IsSatisfiedBy(Beneficiario beneficiario)
        {
            return EmailValidacao.Validate(beneficiario.Email);
        }
    }
}
