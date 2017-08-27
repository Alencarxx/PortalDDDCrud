using System;
using System.IO;
using System.Web;
using AutoMapper;
using PS.PostalBeneficiario.Aplicacao.ViewModels;
using PS.PostalBeneficiario.Aplicacao.Interfaces;
using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Infra.Dado.Interfaces;
using PS.PostalBeneficiario.Dominio.Interfaces.Servicos;

namespace PS.PostalBeneficiario.Aplicacao
{
    public class BeneficiarioAppServico : AplicacaoServico, IBeneficiarioAppServico
    {
        private readonly IBeneficiarioServico _beneficiarioServico;

        public BeneficiarioAppServico(IBeneficiarioServico beneficiarioServico, IUnitOfWork uow)
            : base(uow)
        {
            _beneficiarioServico = beneficiarioServico;
        }

        public BeneficiarioEnderecoViewModel Adicionar(BeneficiarioEnderecoViewModel beneficiarioEnderecoViewModel)
        {
            var benef = Mapper.Map<Beneficiario>(beneficiarioEnderecoViewModel);
            var endereco = Mapper.Map<Endereco>(beneficiarioEnderecoViewModel);

            benef.Enderecos.Add(endereco);
            var foto = beneficiarioEnderecoViewModel.Foto;

            BeginTransaction();

            var beneficiarioReturn = _beneficiarioServico.Adicionar(benef);
            beneficiarioEnderecoViewModel = Mapper.Map<BeneficiarioEnderecoViewModel>(beneficiarioReturn);
            if (!beneficiarioReturn.ValidationResult.IsValid)
            {
                // Não faz o commit
                return beneficiarioEnderecoViewModel;
            }

            if (!SalvarImagemBeneficiario(foto, beneficiarioEnderecoViewModel.BeneficiarioId))
            {
                // Tomada de decisão caso a imagem não seja gravada.
                beneficiarioEnderecoViewModel.ValidationResult.Message = "Beneficiário salvo sem foto";
            }

            Commit();

            return beneficiarioEnderecoViewModel;
        }

        public BeneficiarioViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<BeneficiarioViewModel>(_beneficiarioServico.ObterPorId(id));
        }

        public BeneficiarioViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<BeneficiarioViewModel>(_beneficiarioServico.ObterPorCpf(cpf));
        }

        public BeneficiarioViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<BeneficiarioViewModel>(_beneficiarioServico.ObterPorEmail(email));
        }

        public PagedViewModel<BeneficiarioViewModel> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            return Mapper.Map<PagedViewModel<BeneficiarioViewModel>>(_beneficiarioServico.ObterTodos(nome, pageSize, pageNumber));
        }

        public BeneficiarioViewModel Atualizar(BeneficiarioViewModel beneficiarioViewModel)
        {
            BeginTransaction();
            _beneficiarioServico.Atualizar(Mapper.Map<Beneficiario>(beneficiarioViewModel));
            Commit();
            return beneficiarioViewModel;
        }

        public void Remover(Guid id)
        {
            BeginTransaction();
            _beneficiarioServico.Remover(id);
            Commit();
        }

        public EnderecoViewModel AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<Endereco>(enderecoViewModel);

            BeginTransaction();
            _beneficiarioServico.AdicionarEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<Endereco>(enderecoViewModel);

            BeginTransaction();
            _beneficiarioServico.AtualizarEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel ObterEnderecoPorId(Guid id)
        {
            return Mapper.Map<EnderecoViewModel>(_beneficiarioServico.ObterEnderecoPorId(id));
        }

        public void RemoverEndereco(Guid id)
        {
            BeginTransaction();
            _beneficiarioServico.RemoverEndereco(id);
            Commit();
        }

        public void Dispose()
        {
            _beneficiarioServico.Dispose();
            GC.SuppressFinalize(this);
        }

        private static bool SalvarImagemBeneficiario(HttpPostedFileBase img, Guid id)
        {
            if (img == null || img.ContentLength <= 0) return false;

            const string directory = @"C:\FotoBeneficiario";
            var fileName = id + Path.GetExtension(img.FileName);
            img.SaveAs(Path.Combine(directory, fileName));
            return File.Exists(Path.Combine(directory, fileName));
        }       
    }
}
