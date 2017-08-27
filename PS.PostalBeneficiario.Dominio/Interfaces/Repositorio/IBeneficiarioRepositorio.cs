using PS.PostalBeneficiario.Dominio.DTO;
using PS.PostalBeneficiario.Dominio.Entidades;

namespace PS.PostalBeneficiario.Dominio.Interfaces.Repositorio
{
    public interface IBeneficiarioRepositorio : IRepositorio<Beneficiario>
    {
        Beneficiario ObterPorCpf(string cpf);
        Beneficiario ObterPorEmail(string email);
        Paged<Beneficiario> ObterTodos(string nome, int pageSize, int pageNumber);
    }
}
