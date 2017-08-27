using DomainValidation.Interfaces.Specification;
using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Dominio.Validacoes.Documentos;


namespace PS.PostalBeneficiario.Dominio.Especificacoes.Beneficiarios
{
    public class BeneficiarioDeveTerCpfValidoEspecificacoes : ISpecification<Beneficiario>
    {
        public bool IsSatisfiedBy(Beneficiario beneficiario)
        {
            return CPFValidacao.Validar(beneficiario.CPF);
        }
    }
}
