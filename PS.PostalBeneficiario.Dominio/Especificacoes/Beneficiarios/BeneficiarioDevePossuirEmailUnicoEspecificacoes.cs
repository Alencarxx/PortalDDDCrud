using DomainValidation.Interfaces.Specification;
using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Dominio.Interfaces.Repositorio;

namespace PS.PostalBeneficiario.Dominio.Especificacoes.Beneficiarios
{
    public class BeneficiarioDevePossuirEmailUnicoEspecificacoes : ISpecification<Beneficiario>
    {
        private readonly IBeneficiarioRepositorio _beneficiarioRepositorio;

        public BeneficiarioDevePossuirEmailUnicoEspecificacoes(IBeneficiarioRepositorio beneficiarioRepositorio)
        {
            _beneficiarioRepositorio = beneficiarioRepositorio;
        }

        public bool IsSatisfiedBy(Beneficiario beneficiario)
        {
            return _beneficiarioRepositorio.ObterPorEmail(beneficiario.Email) == null;
        }
    }
}
