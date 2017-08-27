using PS.PostalBeneficiario.Aplicacao;
using PS.PostalBeneficiario.Aplicacao.Interfaces;
using PS.PostalBeneficiario.Dominio.Interfaces.Repositorio;
using PS.PostalBeneficiario.Dominio.Interfaces.Servicos;
using PS.PostalBeneficiario.Dominio.Servicos;
using PS.PostalBeneficiario.Infra.CrossCutting.Logging.Dado;
using PS.PostalBeneficiario.Infra.CrossCutting.Logging.Ajuda;
using PS.PostalBeneficiario.Infra.Dado.Contexto;
using PS.PostalBeneficiario.Infra.Dado.Interfaces;
using PS.PostalBeneficiario.Infra.Dado.Repositorio;
using PS.PostalBeneficiario.Infra.Dado.UoW;
using SimpleInjector;

namespace PS.PostalBeneficiario.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App            
            container.Register<IBeneficiarioAppServico, BeneficiarioAppServico>(Lifestyle.Scoped);

            // Domain
            container.Register<IBeneficiarioServico, BeneficiarioServico>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<IBeneficiarioRepositorio, BeneficiarioRepositorio>(Lifestyle.Scoped);
            container.Register<IEnderecoRepositorio, EnderecoRepositorio>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<PostalBeneficiarioContext>(Lifestyle.Scoped);
            //container.Register(typeof (IRepository<>), typeof (Repository<>));

            // Logging
            container.Register<ILogAuditoria, LogAuditoriaHelper>(Lifestyle.Scoped);
            container.Register<LogginContexto>(Lifestyle.Scoped);
        }
    }
}
