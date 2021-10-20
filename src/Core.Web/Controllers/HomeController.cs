using Core.Business.Entities;
using Core.Business.Interfaces;
using Core.Business.Interfaces.Services;
using Core.Business.ViewModels;
using Core.Business.ViewModels.Identity;
using Core.Web.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Controllers
{
    [CustomAuthorize(new[] { EPerfil.Administrador, EPerfil.Leitor })]
    public class HomeController : MainController
    {
        private readonly IHomeService _homeService;
        private readonly IProjetoService _projetoService;
        public HomeController(IHomeService homeService,
                              INotificador notificador,
                              IProjetoService projetoService,
                              IUser user) : base(notificador, user)
        {
            _homeService = homeService;
            _projetoService = projetoService;
        }

        [DefaultBreadcrumb("Home")]
        public async Task<IActionResult> Index(DashboardViewModel filtros)
        {
            /*DropDowns*/
            var projetos = await _homeService.ProjetosRelatorio();
            ViewBag.DemandantesDDL = new SelectList(projetos.Select(x => new { x.GESTOR_DEMANDANTE, x.NOME_DEMANDANTE }).Distinct().OrderBy(x => x.NOME_DEMANDANTE), "GESTOR_DEMANDANTE", "NOME_DEMANDANTE");
            ViewBag.GerentesDDL = new SelectList(projetos.Select(x => new { x.MATRICULA_GERENTE, x.NOME_GERENTE }).Distinct().OrderBy(x => x.NOME_GERENTE), "MATRICULA_GERENTE", "NOME_GERENTE");
            ViewBag.TipoDDL = new SelectList(projetos.Select(x => new { x.CO_TIPO, x.DESCRICAO_TIPO }).Distinct().OrderBy(x => x.DESCRICAO_TIPO), "CO_TIPO", "DESCRICAO_TIPO");
            ViewBag.SituacaoDDL = new SelectList(projetos.Select(x => new { x.CO_STATUS, x.DESCRICAO_STATUS }).Distinct().OrderBy(x => x.DESCRICAO_STATUS), "CO_STATUS", "DESCRICAO_STATUS");
            ViewBag.CategoriaDDL = new SelectList(projetos.Select(x => new { x.CO_CATEGORIA, x.DESCRICAO_CATEGORIA }).Distinct().OrderBy(x => x.DESCRICAO_CATEGORIA), "CO_CATEGORIA", "DESCRICAO_CATEGORIA");

            DashboardViewModel model = new DashboardViewModel();
            model = filtros;
            model.GraficosDashboard.Add(await _homeService.ObterGraficoPorGerente(filtros));
            model.GraficosDashboard.Add(await _homeService.ObterGraficoPorSituacao(filtros));
            model.GraficosDashboard.Add(await _homeService.ObterGraficoPorCliente(filtros));
            model.GraficosDashboard.Add(await _homeService.ObterGraficoPorDemandante(filtros));
            model.GraficosDashboard.Add(await _homeService.ObterGraficoPorCategoria(filtros));

            var listaProjetos = await _projetoService.ObterTodos(filtros);

            model.Projetos = listaProjetos.OrderByDescending(x => x.PERCENTUAL).ThenBy(y => y.NOME).ToList();
            return  View(model);
        }

        public async Task<IActionResult> RelatorioProjetos()
        {

            var projetos = await _homeService.ProjetosRelatorio();

            ViewBag.DemandantesDDL = new SelectList(projetos.Select(x => new { x.GESTOR_DEMANDANTE, x.NOME_DEMANDANTE }).Distinct().OrderBy(x=> x.NOME_DEMANDANTE), "GESTOR_DEMANDANTE", "NOME_DEMANDANTE");
            ViewBag.GerentesDDL = new SelectList(projetos.Select(x => new { x.MATRICULA_GERENTE, x.NOME_GERENTE }).Distinct().OrderBy(x => x.NOME_GERENTE), "MATRICULA_GERENTE", "NOME_GERENTE");
            ViewBag.TipoDDL = new SelectList(projetos.Select(x => new { x.CO_TIPO, x.DESCRICAO_TIPO}).Distinct().OrderBy(x => x.DESCRICAO_TIPO), "CO_TIPO", "DESCRICAO_TIPO");
            ViewBag.SituacaoDDL = new SelectList(projetos.Select(x => new { x.CO_STATUS, x.DESCRICAO_STATUS }).Distinct().OrderBy(x => x.DESCRICAO_STATUS), "CO_STATUS", "DESCRICAO_STATUS");
            ViewBag.CategoriaDDL = new SelectList(projetos.Select(x => new { x.CO_CATEGORIA, x.DESCRICAO_CATEGORIA }).Distinct().OrderBy(x => x.DESCRICAO_CATEGORIA), "CO_CATEGORIA", "DESCRICAO_CATEGORIA");

            return View(projetos.OrderBy(x=> x.NOME).ThenByDescending(x=> x.COMPLEXIDADE).ThenByDescending(x=> x.PRIORIDADE));
        }

        public async Task<IActionResult> ListarRelatorioProjetos(string Demandante, string Gerente,  int? Tipo, int? Situacao, int? Categoria )
        {

            var projetos = await _homeService.ProjetosRelatorio();

            var model = projetos
                .Where(x => (x.GESTOR_DEMANDANTE == Demandante || Demandante == null) 
                && (x.MATRICULA_GERENTE == Gerente || Gerente == null)
                && (x.CO_TIPO == Tipo || Tipo == null) 
                && (x.CO_STATUS == Situacao || Situacao == null)
                && (x.CO_CATEGORIA == Categoria || Categoria == null));

            return View("_ListarRelatorioProjetos",model.OrderBy(x => x.NOME).ThenByDescending(x => x.COMPLEXIDADE).ThenByDescending(x => x.PRIORIDADE));
        }

        public async Task<IActionResult> ProjetoSlide(string Demandante, string Gerente, int? Tipo, int? Situacao, int? Categoria)
        {
            ProjetoSlideViewModel model = new ProjetoSlideViewModel();
            model.Demandante = Demandante;
            model.Gerente = Gerente;
            model.Tipo = Tipo;
            model.Situacao = Situacao;
            model.Categoria = Categoria;





            ViewBag.ProjetosUsuarioLogado = await _projetoService.ObterIdsProjetoPorMembro(UserCustom.Matricula);
            var projetos = await _homeService.ProjetosRelatorio();
            ViewBag.CategoriaDDL = new SelectList(projetos.Select(x => new { x.CO_CATEGORIA, x.DESCRICAO_CATEGORIA }).Distinct().OrderBy(x => x.DESCRICAO_CATEGORIA), "CO_CATEGORIA", "DESCRICAO_CATEGORIA");
            ViewBag.DemandantesDDL = new SelectList(projetos.Select(x => new { x.GESTOR_DEMANDANTE, x.NOME_DEMANDANTE }).Distinct().OrderBy(x => x.NOME_DEMANDANTE), "GESTOR_DEMANDANTE", "NOME_DEMANDANTE");
            ViewBag.GerentesDDL = new SelectList(projetos.Select(x => new { x.MATRICULA_GERENTE, x.NOME_GERENTE }).Distinct().OrderBy(x => x.NOME_GERENTE), "MATRICULA_GERENTE", "NOME_GERENTE");
            ViewBag.TipoDDL = new SelectList(projetos.Select(x => new { x.CO_TIPO, x.DESCRICAO_TIPO }).Distinct().OrderBy(x => x.DESCRICAO_TIPO), "CO_TIPO", "DESCRICAO_TIPO");
            ViewBag.SituacaoDDL = new SelectList(projetos.Select(x => new { x.CO_STATUS, x.DESCRICAO_STATUS }).Distinct().OrderBy(x => x.DESCRICAO_STATUS), "CO_STATUS", "DESCRICAO_STATUS");
         
            model.ListaProjetos = await _projetoService.ObterTodosProjetosComIncludes();
            model.ListaProjetos = model.ListaProjetos.Where(x => (x.CO_CATEGORIA == Categoria || Categoria == null || (Categoria == 0 && x.CO_CATEGORIA == null))
            && (x.GESTOR_DEMANDANTE == Demandante || Demandante == null)
                && (x.MATRICULA_GERENTE == Gerente || Gerente == null)
                && (x.CO_TIPO == Tipo || Tipo == null)
                && (x.CO_STATUS == Situacao || Situacao == null)
            );
            ViewBag.Categoria = Categoria;
            //model.OrderBy(x => x.Gerente != null ? x.Gerente.Nome : "zzzzz").ThenBy(x => x.NOME)
            return  View(model) ;
         
        }



    }
}
