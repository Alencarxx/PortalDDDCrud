using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Dominio.Interfaces.Repositorio;
using PS.PostalBeneficiario.Infra.Dado.Contexto;

namespace PS.PostalBeneficiario.Infra.Dado.Repositorio
{
    public class EnderecoRepositorio : Repositorio<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(PostalBeneficiarioContext context)
            : base(context)
        {

        }
    }
}
