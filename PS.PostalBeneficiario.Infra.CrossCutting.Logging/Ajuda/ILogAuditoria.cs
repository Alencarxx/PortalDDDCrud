using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using PS.PostalBeneficiario.Infra.CrossCutting.Logging.Modelo;

namespace PS.PostalBeneficiario.Infra.CrossCutting.Logging.Ajuda
{
    public interface ILogAuditoria : IDisposable
    {
        void RegistrarLog(ActionExecutedContext filterContext);
        IEnumerable<Auditoria> ObterLogs();
        IEnumerable<Auditoria> Buscar(Expression<Func<Auditoria, bool>> predicate);
    }
}
