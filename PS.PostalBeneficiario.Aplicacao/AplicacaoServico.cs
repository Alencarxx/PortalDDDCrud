using PS.PostalBeneficiario.Infra.Dado.Interfaces;

namespace PS.PostalBeneficiario.Aplicacao
{
    public class AplicacaoServico
    {
        private readonly IUnitOfWork _uow;

        public AplicacaoServico(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}
