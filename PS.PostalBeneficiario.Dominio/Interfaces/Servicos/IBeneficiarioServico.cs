using System;
using PS.PostalBeneficiario.Dominio.DTO;
using PS.PostalBeneficiario.Dominio.Entidades;

namespace PS.PostalBeneficiario.Dominio.Interfaces.Servicos
{
    public interface IBeneficiarioServico : IDisposable
    {
        Beneficiario Adicionar(Beneficiario beneficiario);
        Beneficiario ObterPorId(Guid id);
        Beneficiario ObterPorCpf(string cpf);
        Beneficiario ObterPorEmail(string email);
        Paged<Beneficiario> ObterTodos(string nome, int pageSize, int pageNumber);
        Beneficiario Atualizar(Beneficiario beneficiario);
        void Remover(Guid id);

        Endereco AdicionarEndereco(Endereco endereco);
        Endereco AtualizarEndereco(Endereco endereco);
        Endereco ObterEnderecoPorId(Guid id);
        void RemoverEndereco(Guid id);
    }
}
