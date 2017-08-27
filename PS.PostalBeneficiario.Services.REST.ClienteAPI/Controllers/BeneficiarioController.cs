using System;
using System.Collections.Generic;
using System.Web.Http;
using PS.PostalBeneficiario.Aplicacao.Interfaces;
using PS.PostalBeneficiario.Aplicacao.ViewModels;

namespace PS.PostalBeneficiario.Services.REST.BeneficiarioAPI.Controllers
{
    public class BeneficiarioController : ApiController
    {
        private readonly IBeneficiarioAppServico _beneficiarioAppServico;

        public BeneficiarioController(IBeneficiarioAppServico beneficiarioAppServico)
        {
            _beneficiarioAppServico = beneficiarioAppServico;
        }

        // GET: api/Beneficiarios
        [HttpGet]
        public IEnumerable<BeneficiarioViewModel> ListarTodos(string nome, int pageSize, int pageNumber)
        {
            return _beneficiarioAppServico.ObterTodos(nome, pageSize, pageNumber).List;
        }

        // GET: api/Beneficiarios/5
        public BeneficiarioViewModel Get(Guid id)
        {
            return _beneficiarioAppServico.ObterPorId(id);
        }

        // POST: api/Beneficiarios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Beneficiarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Beneficiarios/5
        public void Delete(int id)
        {
        }
    }
}