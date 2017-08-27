using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PS.PostalBeneficiario.Dominio.Interfaces.Repositorio
{
    public interface IRepositorio<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
