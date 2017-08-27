using System.Linq;
using DomainValidation.Interfaces.Specification;
using PS.PostalBeneficiario.Dominio.Entidades;

namespace PS.PostalBeneficiario.Dominio.Especificacoes.Beneficiarios
{
    public class BeneficiarioDeveTerUmEnderecoEspecificacoes : ISpecification<Beneficiario>
    {
        public bool IsSatisfiedBy(Beneficiario beneficiario)
        {
            return beneficiario.Enderecos != null && beneficiario.Enderecos.Any();
        }
    }
}
