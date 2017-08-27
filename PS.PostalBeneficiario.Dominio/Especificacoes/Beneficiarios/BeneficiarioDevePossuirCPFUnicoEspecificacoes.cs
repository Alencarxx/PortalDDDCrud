using DomainValidation.Interfaces.Specification;
using PS.PostalBeneficiario.Dominio.Interfaces.Repositorio;
using PS.PostalBeneficiario.Dominio.Entidades;

namespace PS.PostalBeneficiario.Dominio.Especificacoes.Beneficiarios
{
    public class BeneficiarioDevePossuirCPFUnicoEspecificacoes : ISpecification<Beneficiario>
    {
        private readonly IBeneficiarioRepositorio _beneficiarioRepository;

        public BeneficiarioDevePossuirCPFUnicoEspecificacoes(IBeneficiarioRepositorio beneficiarioRepository)
        {
            _beneficiarioRepository = beneficiarioRepository;
        }

        public bool IsSatisfiedBy(Beneficiario beneficiario)
        {
            return _beneficiarioRepository.ObterPorCpf(beneficiario.CPF) == null;
        }
    }
}
