using System;
using PS.PostalBeneficiario.Infra.Dado.Contexto;
using PS.PostalBeneficiario.Infra.Dado.Interfaces;

namespace PS.PostalBeneficiario.Infra.Dado.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostalBeneficiarioContext _context;
        private bool _disposed;

        public UnitOfWork(PostalBeneficiarioContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
