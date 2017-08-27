namespace PS.PostalBeneficiario.Infra.Dado.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
