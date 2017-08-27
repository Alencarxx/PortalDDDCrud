using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PS.PostalBeneficiario.Aplicacao.Interfaces;
using PS.PostalBeneficiario.Aplicacao.ViewModels;
using PS.PostalBeneficiario.Infra.CrossCutting.MvcFlte;
using Microsoft.Ajax.Utilities;

namespace PS.PostalBeneficiario.UI.MVC.Controllers
{
    [Authorize]
    [RoutePrefix("administrativo-beneficiarios")]
    [Route("{action=listar}")]
    public class BeneficiariosController : BaseController
    {
        private readonly IBeneficiarioAppServico _beneficiarioAppServico;

        public BeneficiariosController(IBeneficiarioAppServico BeneficarioAppServico)
        {
            _beneficiarioAppServico = BeneficarioAppServico;
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CL")]
        [Route("listar")]
        public ActionResult Index(string buscar, int pageNumber = 1)
        {
            var paged = _beneficiarioAppServico.ObterTodos(buscar, PageSize, pageNumber);
            if(paged == null) { return HttpNotFound(); }
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;

            return View(paged.List);
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CV")]
        [Route("detalhes/{id:guid}")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeneficiarioViewModel beneficarioViewModel = _beneficiarioAppServico.ObterPorId(id.Value);
            if (beneficarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(beneficarioViewModel);
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CI")]
        [Route("incluir-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CI")]
        [Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeneficiarioEnderecoViewModel beneficiarioEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                beneficiarioEnderecoViewModel = _beneficiarioAppServico.Adicionar(beneficiarioEnderecoViewModel);

                if (!beneficiarioEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in beneficiarioEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(beneficiarioEnderecoViewModel);
                }


                if (!beneficiarioEnderecoViewModel.ValidationResult.Message.IsNullOrWhiteSpace())
                {
                    ViewBag.Sucesso = beneficiarioEnderecoViewModel.ValidationResult.Message;
                    return View(beneficiarioEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(beneficiarioEnderecoViewModel);
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CE")]
        [Route("editar/{id:guid}")]
        public ActionResult Edit(Guid? id)
        {
            ViewBag.Acao = "Editar Beneficiário";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeneficiarioViewModel beneficiarioViewModel = _beneficiarioAppServico.ObterPorId(id.Value);
            if (beneficiarioViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.BeneficiarioId = id;
            return View(beneficiarioViewModel);
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CE")]
        [Route("editar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BeneficiarioViewModel beneficiarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _beneficiarioAppServico.Atualizar(beneficiarioViewModel);
                return RedirectToAction("Index");
            }
            return View(beneficiarioViewModel);
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CX")]
        [Route("excluir/{id:guid}")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeneficiarioViewModel beneficiarioViewModel = _beneficiarioAppServico.ObterPorId(id.Value);
            if (beneficiarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(beneficiarioViewModel);
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CX")]
        [Route("excluir/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _beneficiarioAppServico.Remover(id);
            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CV")]
        public ActionResult ListarEnderecos(Guid id)
        {
            ViewBag.BeneficiarioId = id;
            return PartialView("_EnderecosList", _beneficiarioAppServico.ObterPorId(id).Enderecos);
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CE")]
        [Route("adicionar-endereco")]
        public ActionResult AdicionarEndereco(Guid id)
        {
            ViewBag.BeneficiarioId = id;
            return PartialView("_AdicionarEndereco");
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CE")]
        [Route("adicionar-endereco")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _beneficiarioAppServico.AdicionarEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Beneficiarios", new { id = enderecoViewModel.BeneficiarioId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarEndereco", enderecoViewModel);
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CE")]
        [Route("adicionar-endereco/{id:guid}")]
        public ActionResult AtualizarEndereco(Guid id)
        {
            return PartialView("_AtualizarEndereco", _beneficiarioAppServico.ObterEnderecoPorId(id));
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CE")]
        [Route("adicionar-endereco/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _beneficiarioAppServico.AtualizarEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Beneficiarios", new { id = enderecoViewModel.BeneficiarioId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AtualizarEndereco", enderecoViewModel);
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CE")]
        [Route("excluir-endereco/{id:guid}")]
        public ActionResult DeletarEndereco(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var enderecoViewModel = _beneficiarioAppServico.ObterEnderecoPorId(id.Value);
            if (enderecoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarEndereco", enderecoViewModel);
        }

        [ClaimsAuthorize("PermissoesBeneficiario", "CE")]
        [Route("excluir-endereco/{id:guid}")]
        [HttpPost, ActionName("DeletarEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarEnderecoConfirmed(Guid id)
        {
            var beneficiarioId = _beneficiarioAppServico.ObterEnderecoPorId(id).BeneficiarioId;
            _beneficiarioAppServico.RemoverEndereco(id);

            string url = Url.Action("ListarEnderecos", "Beneficiarios", new { id = beneficiarioId });
            return Json(new { success = true, url = url });
        }

        public ActionResult ObterImagemBeneficiario(Guid id)
        {
            var root = @"C:\PortalBeneficiario\ beneficiarios\";
            var foto = Directory.GetFiles(root, id + "*").FirstOrDefault();

            if (foto != null && !foto.StartsWith(root))
            {
                // Validando qualquer acesso indevido além da pasta permitida
                throw new HttpException(403, "Acesso Negado");
            }

            if (foto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return File(foto, "image/jpeg");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _beneficiarioAppServico.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}