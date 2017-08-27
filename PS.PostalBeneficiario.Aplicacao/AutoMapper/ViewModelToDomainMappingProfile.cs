using AutoMapper;
using PS.PostalBeneficiario.Aplicacao.ViewModels;
using PS.PostalBeneficiario.Dominio.Entidades;

namespace PS.PostalBeneficiario.Aplicacao.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<BeneficiarioViewModel, Beneficiario>();
            CreateMap<BeneficiarioEnderecoViewModel, Beneficiario>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<BeneficiarioEnderecoViewModel, Endereco>();
        }
    }
}
