using System;
using PS.PostalBeneficiario.Dominio.DTO;
using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Dominio.Interfaces.Repositorio;
using PS.PostalBeneficiario.Dominio.Interfaces.Servicos;
using PS.PostalBeneficiario.Dominio.Validacoes.Beneficiarios;

namespace PS.PostalBeneficiario.Dominio.Servicos
{
    public class BeneficiarioServico : IBeneficiarioServico
    {
        private readonly IBeneficiarioRepositorio _beneficiarioRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public BeneficiarioServico(IBeneficiarioRepositorio beneficiarioRepositorio, IEnderecoRepositorio enderecoRepositorio)
        {
            _beneficiarioRepositorio = beneficiarioRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }

        public Beneficiario Adicionar(Beneficiario beneficiario)
        {
            //if (!beneficiario.IsValid())
            //{
            //    return beneficiario;
            //}

            //beneficiario.ValidationResult = new BeneficiarioAptoParaCadastroValidacoes(_beneficiarioRepositorio).Validate(beneficiario);
            //if (!beneficiario.ValidationResult.IsValid)
            //{
            //    return beneficiario;
            //}

            //beneficiario.ValidationResult.Message = "Beneficiario cadastrado com sucesso :)";
            return _beneficiarioRepositorio.Adicionar(beneficiario);
        }

        public Beneficiario ObterPorId(Guid id)
        {
            return _beneficiarioRepositorio.ObterPorId(id);
        }

        public Beneficiario ObterPorCpf(string cpf)
        {
            return _beneficiarioRepositorio.ObterPorCpf(cpf);
        }

        public Beneficiario ObterPorEmail(string email)
        {
            return _beneficiarioRepositorio.ObterPorEmail(email);
        }

        public Paged<Beneficiario> ObterTodos(string nome, int pageSize, int pageNumber)
        {            
            return _beneficiarioRepositorio.ObterTodos(nome, pageSize, pageNumber);
        }

        public Beneficiario Atualizar(Beneficiario beneficiario)
        {
            return _beneficiarioRepositorio.Atualizar(beneficiario);
        }

        public void Remover(Guid id)
        {
            _beneficiarioRepositorio.Remover(id);
        }

        public Endereco AdicionarEndereco(Endereco endereco)
        {
            return _enderecoRepositorio.Adicionar(endereco);
        }

        public Endereco AtualizarEndereco(Endereco endereco)
        {
            return _enderecoRepositorio.Atualizar(endereco);
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            return _enderecoRepositorio.ObterPorId(id);
        }

        public void RemoverEndereco(Guid id)
        {
            _enderecoRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _beneficiarioRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
