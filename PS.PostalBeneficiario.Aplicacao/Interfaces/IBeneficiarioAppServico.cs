using System;
using PS.PostalBeneficiario.Aplicacao.ViewModels;

namespace PS.PostalBeneficiario.Aplicacao.Interfaces
{
    public interface IBeneficiarioAppServico : IDisposable
    {
        BeneficiarioEnderecoViewModel Adicionar(BeneficiarioEnderecoViewModel beneficiarioEnderecoViewModel);
        BeneficiarioViewModel ObterPorId(Guid id);
        BeneficiarioViewModel ObterPorCpf(string cpf);
        BeneficiarioViewModel ObterPorEmail(string email);
        PagedViewModel<BeneficiarioViewModel> ObterTodos(string nome, int pageSize, int pageNumber);
        BeneficiarioViewModel Atualizar(BeneficiarioViewModel beneficiarioViewModel);
        void Remover(Guid id);

        EnderecoViewModel AdicionarEndereco(EnderecoViewModel endereco);
        EnderecoViewModel AtualizarEndereco(EnderecoViewModel endereco);
        EnderecoViewModel ObterEnderecoPorId(Guid id);
        void RemoverEndereco(Guid id);        
    }
}