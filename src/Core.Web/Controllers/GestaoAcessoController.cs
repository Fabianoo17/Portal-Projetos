using Core.Business.Interfaces;
using Core.Business.Interfaces.Services;
using Core.Business.ViewModels.Identity;
using Core.Web.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Controllers
{
    [CustomAuthorize(new[] { EPerfil.Administrador, EPerfil.Gerente, EPerfil.Leitor })]
    [Route("gestao-acesso")]
    public class GestaoAcessoController : MainController
    {
        private readonly ILogger<GestaoAcessoController> _logger;
        private readonly IUsuarioService _usuarioService;

        public GestaoAcessoController(INotificador notificador,
                                      IUser user,
                                      ILogger<GestaoAcessoController> logger,
                                      IUsuarioService usuarioService) : base(notificador, user)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [CustomAuthorize(new[] { EPerfil.Administrador })]
        [Breadcrumb("Gestão Acesso")]
        [HttpGet("listar-usuarios")]
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.ObterUsuariosAcesso();
            return View(usuarios);
        }

        [CustomAuthorize(new[] { EPerfil.Administrador })]
        [HttpGet("cadastrar-usuario")]
        [Breadcrumb("ViewData.Title", FromAction = nameof(Index))]
        public async Task<IActionResult> Create()
        {
            ViewBag.DropdownUsuarios = new SelectList(new List<dynamic>());
            ViewBag.DropdownPerfis = await DropdownPerfis();

            return View();
        }

        [CustomAuthorize(new[] { EPerfil.Administrador })]
        [HttpPost("cadastrar-usuario")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioAcessoCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.Cadastrar(viewModel);

                if (OperacaoValida())
                {
                    TempData["Success"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.DropdownUsuarios = await DropdownUsuarios(viewModel.Matricula);
            ViewBag.DropdownPerfis = await DropdownPerfis();

            return View(viewModel);
        }

        [CustomAuthorize(new[] { EPerfil.Administrador })]
        [HttpGet("editar-usuario/{matricula}")]
        [Breadcrumb("ViewData.Title", FromAction = nameof(Index))]
        public async Task<IActionResult> Edit(string matricula)
        {
            var usuarioAcesso = await _usuarioService.ObterUsuarioAcessoPorMatricula(matricula);
            if (usuarioAcesso == null)
                return NotFound();

            var model = new UsuarioAcessoCreateEditViewModel
            {
                Matricula = usuarioAcesso.Matricula,
                Perfis = usuarioAcesso.UsuariosPerfis.Select(x => x.PERFIL_ID).ToArray()
            };

            ViewBag.DropdownUsuarios = await DropdownUsuarios(matricula);
            ViewBag.DropdownPerfis = await DropdownPerfis();

            return View(model);
        }

        [CustomAuthorize(new[] { EPerfil.Administrador })]
        [HttpPost("editar-usuario/{matricula}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string matricula, UsuarioAcessoCreateEditViewModel viewModel)
        {
            if (matricula.ToUpper() != viewModel.Matricula)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _usuarioService.Atualizar(viewModel);

                if (OperacaoValida())
                {
                    TempData["Success"] = "Usuário alterado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.DropdownUsuarios = await DropdownUsuarios(viewModel.Matricula);
            ViewBag.DropdownPerfis = await DropdownPerfis();

            return View(viewModel);
        }

        [CustomAuthorize(new[] { EPerfil.Administrador })]
        [HttpGet("excluir-usuario/{matricula}")]
        [Breadcrumb("ViewData.Title", FromAction = nameof(Index))]
        public async Task<IActionResult> Delete(string matricula)
        {
            var usuarioAcesso = await _usuarioService.ObterUsuarioAcessoPorMatricula(matricula);
            if (usuarioAcesso == null)
                return NotFound();

            return View(usuarioAcesso);
        }

        [CustomAuthorize(new[] { EPerfil.Administrador })]
        [ValidateAntiForgeryToken]
        [HttpPost("excluir-usuario/{matricula}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string matricula)
        {
            await _usuarioService.Excluir(matricula);

            if (OperacaoValida())
            {
                TempData["Success"] = "Usuário excluído com sucesso.";
                return RedirectToAction(nameof(Index));
            }

            var usuarioAcesso = await _usuarioService.ObterUsuarioAcessoPorMatricula(matricula);
            return View(usuarioAcesso);
        }

        [CustomAuthorize(new[] { EPerfil.Gerente })]
        [HttpGet("vinculacao")]
        [Breadcrumb("ViewData.Title", FromAction = nameof(Index))]
        public async Task<IActionResult> Vinculacao()
        {
            var model = await _usuarioService.ObterVinculosPorGerente(UserCustom.Matricula);
            ViewBag.DropDownApoios = await DropDownUsuariosVinculadosAoGerente();

            return View(model);
        }

        [CustomAuthorize(new[] { EPerfil.Gerente })]
        [HttpPost("vinculacao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Vinculacao(UsuarioVinculadoViewModel viewModel)
        {
            await _usuarioService.AtualizarVinculacao(viewModel);
            if (OperacaoValida())
            {
                TempData["Success"] = "Vinculação atualizada com sucesso!";
                return RedirectToAction(nameof(Vinculacao));
            }

            ViewBag.DropDownApoios = await DropDownUsuariosVinculadosAoGerente();

            return View(viewModel);
        }
        
        [CustomAuthorize(new[] { EPerfil.Leitor })]
        [HttpPost("pesquisar-usuarios")]
        public async Task<IActionResult> PesquisarUsuarios(string matriculaOuNome)
        {
            var usuarios = await _usuarioService.PesquisarUsuarios(matriculaOuNome);
            var usuariosSelect = usuarios.Select(x => new { id = x.Matricula, text = $"{x.Nome} - {x.Matricula}" }).ToList();
            return Json(new { results = usuariosSelect });
        }

        private async Task<SelectList> DropdownPerfis()
        {
            var perfis = await _usuarioService.ObterPerfis();
            return new SelectList(perfis, "PERFIL_ID", "NOME");
        }

        private async Task<SelectList> DropdownUsuarios(string matricula)
        {
            var usuarios = await _usuarioService.PesquisarUsuarios(matricula);
            return new SelectList(usuarios, "Matricula", "NomeEMatricula");
        }

        private async Task<SelectList> DropDownUsuariosVinculadosAoGerente()
        {
            var model = await _usuarioService.ObterUsuariosVinculadosPorGerente(UserCustom.Matricula);
            return new SelectList(model, "Matricula", "NomeEMatricula");
        }
    }
}