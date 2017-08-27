using AutoMapper;
using PS.PostalBeneficiario.Aplicacao.ViewModels;
using PS.PostalBeneficiario.Dominio.DTO;
using PS.PostalBeneficiario.Dominio.Entidades;

namespace PS.PostalBeneficiario.Aplicacao.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Beneficiario, BeneficiarioViewModel>();
            CreateMap<Beneficiario, BeneficiarioEnderecoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Endereco, BeneficiarioEnderecoViewModel>();
            CreateMap<Paged<Beneficiario>, PagedViewModel<BeneficiarioViewModel>>();
            //Mapper.AssertConfigurationIsValid();
        }
    }
}
