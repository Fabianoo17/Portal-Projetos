using AutoMapper;
using Core.Business.Entities.Graphs;
using Core.Business.Entities.Projetos;
using Core.Business.Enums;
using Core.Business.Interfaces;
using Core.Business.Interfaces.Services;
using Core.Business.ViewModels;
using Core.Business.ViewModels.Identity;
using Core.Business.ViewModels.Projetos;
using Core.Web.Models;
using Core.Web.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core.Business.Entities.Graphs.OrgChart;

namespace Core.Web.Controllers
{
    [CustomAuthorize(new[] { EPerfil.Administrador, EPerfil.Leitor, EPerfil.Gerente })]
    [Route("projetos")]
    public partial class ProjetoController : MainController
    {
        private readonly IProjetoService _projetoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IParametroService _parametroService;
        private readonly IMapper _mapper;


        public ProjetoController(INotificador notificador,
                                 IUser user,
                                 IProjetoService projetoService,
                                 IParametroService parametroService,
                                 IUsuarioService usuarioService,
                                 IMapper mapper) : base(notificador, user)
        {
            _projetoService = projetoService;
            _usuarioService = usuarioService;
            _parametroService = parametroService;
            _mapper = mapper;
        }



        [Breadcrumb("Projetos")]
        [HttpGet("listar")]
        public async Task<IActionResult> Index()
        {
            DashboardViewModel filtro = new DashboardViewModel();
            ViewBag.ProjetosUsuarioLogado = await _projetoService.ObterIdsProjetoPorMembro(UserCustom.Matricula);
            var model = await _projetoService.ObterTodos(filtro);
            model = model.Where(x => x.IS_RASCUNHO == false).OrderBy(x => x.NOME);

            return View(model);
        }

        [Administrador]
        [Breadcrumb("Cadastrar", FromAction = nameof(Index))]
        [HttpGet("cadastrar")]
        public async Task<IActionResult> Create()
        {
            ViewData["Title"] = "Cadastrar";

            ViewBag.DropDownTipos = await DropDownTipos();
            ViewBag.DropDownStatus = await DropDownStatus();
            ViewBag.DropDownGerentes = await DropDownGerentes();
            ViewBag.DropDownComplexidades = await DropDownComplexidade();
            ViewBag.DropDownPrioridades = await DropDownPrioridades();
            ViewBag.DropDownCategorias = await DropDownCategoria();
            ViewBag.DropDownProjetos = await DropDownProjetos();
            ViewBag.Responsavel = await DropDownResponsaveis(0);

            var viewModel = new ProjetoViewModel();
            viewModel.Objetivos.Add(new ObjetivoViewModel());
            viewModel.Custos.Add(new CustoViewModel());
            viewModel.Justificativas.Add(new JustificativaViewModel());
            viewModel.Restricoes.Add(new RestricaoViewModel());
            viewModel.Riscos.Add(new RiscoViewModel());
            viewModel.Beneficios.Add(new BeneficioViewModel());
            viewModel.Premissas.Add(new PremissaViewModel());
            viewModel.MarcosEntregas.Add(new MarcosEntregaViewModel
            {
                AtividadesEntregas = new List<AtividadesEntregaViewModel> {
                    new AtividadesEntregaViewModel()
                }
            });
            viewModel.PartesInteressadas.Add(new ParteInteressadaViewModel());
            viewModel.EquipeApoio.Add(new ApoioViewModel());
            viewModel.NaoEscopos.Add(new NaoEscopoViewModel());
            viewModel.Escopos.Add(new EscopoViewModel());
            viewModel.Requisitos.Add(new RequisitoViewModels());
            viewModel.TipoMarcosEntregas = await _parametroService.ObterTipoMarcosEntregas();
            viewModel.TipoMarcosEntregas = await _parametroService.ObterTipoMarcosEntregas();
            viewModel.StatusAtividadeMarcoEntrega = await _parametroService.ObterStatusAtvidadeMarcosEntrega();
            viewModel.marcosEntregasAtivos = await _projetoService.ObterListaMarcos();
            return View("CreateOrEdit", viewModel);
        }

        [AdministradorOuGerenteOuVinculado]
        [HttpGet("itens/{CO_PROJETO:int}")]
        public async Task<IActionResult> ListarItensProjeto(int CO_PROJETO, TipoItemProjeto tipoItemProjeto)
        {
            var model = await _projetoService.ObterItensProjeto(CO_PROJETO, tipoItemProjeto);

            switch (tipoItemProjeto)
            {
                case TipoItemProjeto.Apoio:
                //var viewModel = _mapper.Map<IEnumerable<ApoioViewModel>>((IEnumerable<Apoio>)model);
                //return PartialView("", viewModel);

                case TipoItemProjeto.Beneficio:
                    break;
                case TipoItemProjeto.Custo:
                    break;
                case TipoItemProjeto.Escorpo:
                    break;
                case TipoItemProjeto.Justificativa:
                    break;
                case TipoItemProjeto.NaoEscorpo:
                    break;
                case TipoItemProjeto.MarcosEntrega:
                    break;
                case TipoItemProjeto.MarcosEntregaRelacionado:
                    break;
                case TipoItemProjeto.Objetivo:
                    var viewModel = _mapper.Map<IEnumerable<ObjetivoViewModel>>((IEnumerable<Objetivo>)model);
                    return PartialView("_Objetivos", viewModel);

                case TipoItemProjeto.ParteInteressada:
                    break;
                case TipoItemProjeto.Premissa:
                    break;
                case TipoItemProjeto.Requisito:
                    break;
                case TipoItemProjeto.Restricao:
                    break;
                case TipoItemProjeto.Risco:
                    break;
            }

            return NotFound();
        }

        [AdministradorOuGerenteOuVinculado]
        [HttpPost("CarreagarFormItensProjeto")]
        public async Task<IActionResult> CarreagarFormItensProjeto(TipoItemProjeto tipoItemProjeto)
        {
            switch (tipoItemProjeto)
            {
                case TipoItemProjeto.Apoio:
                //var viewModel = _mapper.Map<IEnumerable<ApoioViewModel>>((IEnumerable<Apoio>)model);
                //return PartialView("", viewModel);

                case TipoItemProjeto.Beneficio:
                    break;
                case TipoItemProjeto.Custo:
                    break;
                case TipoItemProjeto.Escorpo:
                    break;
                case TipoItemProjeto.Justificativa:
                    break;
                case TipoItemProjeto.NaoEscorpo:
                    break;
                case TipoItemProjeto.MarcosEntrega:
                    break;
                case TipoItemProjeto.MarcosEntregaRelacionado:
                    break;
                case TipoItemProjeto.Objetivo:
                    return PartialView("Forms/_FormObjetivos");

                case TipoItemProjeto.ParteInteressada:
                    break;
                case TipoItemProjeto.Premissa:
                    break;
                case TipoItemProjeto.Requisito:
                    break;
                case TipoItemProjeto.Restricao:
                    break;
                case TipoItemProjeto.Risco:
                    break;
            }

            return NotFound();
        }

        [AdministradorOuGerenteOuVinculado]
        [HttpPost("CarreagarFormItensProjeto")]
        public async Task<IActionResult> SalvarEditarObjetivo(ObjetivoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _projetoService.CadastrarOuAtualizarItens(viewModel);
                if (OperacaoValida())
                    return CustomResponse();
            }
            return CustomResponse(ModelState);
        }

        [AdministradorOuGerenteOuVinculado]
        [Breadcrumb("Editar", FromAction = nameof(Index))]
        [HttpGet("editar/{CO_PROJETO:int}")]
        public async Task<IActionResult> Edit(int CO_PROJETO)
        {
            var model = await _projetoService.ObterPorId(CO_PROJETO);

            if (model == null)
                return NotFound();

            ViewData["Title"] = "Editar";

            ViewBag.DropDownPatrocinadores = await DropDownPatrocinadores(model.MATRICULA_PATROCINADOR);
            ViewBag.DropDownTipos = await DropDownTiposEdit(CO_PROJETO);
            ViewBag.DropDownStatus = await DropDownStatusEdit(CO_PROJETO);
            ViewBag.DropDownGerentes = await DropDownGerentes();
            ViewBag.DropDownComplexidades = await DropDownComplexidadeEdit(CO_PROJETO);
            ViewBag.DropDownPrioridades = await DropDownPrioridadesEdit(CO_PROJETO);
            ViewBag.DropDownCategorias = await DropDownCategoriaEdit(CO_PROJETO);
            ViewBag.DropDownProjetos = await DropDownProjetosEdit(CO_PROJETO);
            ViewBag.Responsavel = await DropDownResponsaveis(CO_PROJETO);
            model.TipoMarcosEntregas = await _parametroService.ObterTipoMarcosEntregas();
            model.StatusAtividadeMarcoEntrega = await _parametroService.ObterStatusAtvidadeMarcosEntrega();
            model.marcosEntregasAtivos = await _projetoService.ObterListaMarcos();

            return View("CreateOrEdit", model);
        }

        [AdministradorOuGerenteOuVinculado]
        [HttpPost("cadastrar-editar/{CO_PROJETO:int?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int CO_PROJETO, ProjetoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string mensagem;
                if (viewModel.CO_PROJETO == 0)
                    mensagem = "Projeto cadastrado com sucesso.";
                else
                    mensagem = "Projeto atualizado com sucesso.";

                var projeto = await _projetoService.CadastrarOuAtualizar(viewModel);
                if (OperacaoValida())
                {
                    var result = new
                    {
                        mensagem,
                        projetoId = projeto.CO_PROJETO
                    };
                    return CustomResponse(result);
                }
            }

            return CustomResponse(ModelState);
        }

        [Breadcrumb("Detalhes", FromAction = nameof(Index))]
        [HttpGet("detalhes/{CO_PROJETO:int}")]
        public async Task<IActionResult> Details(int CO_PROJETO)
        {
            var model = await _projetoService.ObterPorId(CO_PROJETO);
            if (model == null)
                return NotFound();

            ViewBag.DropDownPatrocinadores = await DropDownPatrocinadores(model.MATRICULA_PATROCINADOR);
            ViewBag.DropDownTipos = await DropDownTipos();
            ViewBag.DropDownCategoria = await DropDownCategoria();
            ViewBag.DropDownStatus = await DropDownStatus();
            ViewBag.DropDownGerentes = await DropDownGerentes();
            ViewBag.DropDownProjetos = await DropDownProjetos();


            return View(model);
        }

        [Breadcrumb("Projetos")]
        [HttpGet("eap/{id:int}")]
        public async Task<IActionResult> EAP(int id)
        {
            OrgChart nodesList = new OrgChart();

            Nodes node = new Nodes();



            var Projeto = await _projetoService.ObterPorId(id);
            node.id = "Projeto";
            node.title = "Dt Início: " + Projeto.DT_INICIO + "| Dt fim: " + Projeto.DT_FIM + (Projeto.PERCENTUAL != null ? "| Progresso: " + Projeto.PERCENTUAL + "%" : "");
            node.name = Projeto.NOME;
            node.layout = "hanging";


            nodesList.Nodes.Add(node);

            if (Projeto.CO_PROJETO_PAI != null)
            {
                Data data = new Data();
                Nodes nodePrograma = new Nodes();
                int idPai = Convert.ToInt32(Projeto.CO_PROJETO_PAI);
                var programa = await _projetoService.ObterPorId(idPai);

                nodePrograma.id = "Programa";
                nodePrograma.title = "Dt Início: " + programa.DT_INICIO + "| Dt fim: " + programa.DT_FIM + (programa.PERCENTUAL != null ? "| Progresso: " + programa.PERCENTUAL + "%" : "");
                nodePrograma.name = programa.NOME;

                nodesList.Nodes.Add(nodePrograma);

                data.pai = nodePrograma.id;
                data.filho = node.id;

                nodesList.data.Add(data);


            }





            if (Projeto.MarcosEntregas.Any())
            {

                foreach (var item in Projeto.MarcosEntregas)
                {

                    Data data = new Data();
                    Nodes marcos = new Nodes();

                    marcos.id = "Entrega" + item.CO_MARCOS_ENTREGA;
                    marcos.title = "Dt fim: " + item.DT_PREVISAO + "<br/> Situação: " + item.SituacaoEntrega.DESCRICAO;
                    marcos.name = item.DESCRICAO;
                    marcos.color = obterCor(item.DT_PREVISAO, item.SituacaoEntrega.DESCRICAO);


                    data.pai = node.id;
                    data.filho = marcos.id;

                    nodesList.data.Add(data);

                    nodesList.Nodes.Add(marcos);
                }

            }

            return View(nodesList);
        }


        [Administrador]
        [HttpGet("excluir/{CO_PROJETO:int}")]
        [Breadcrumb("ViewData.Title", FromAction = nameof(Index))]
        public async Task<IActionResult> Delete(int CO_PROJETO)
        {
            var projeto = await _projetoService.ObterPorId(CO_PROJETO);
            if (projeto == null)
                return NotFound();

            return View(projeto);
        }

        [Administrador]
        [ValidateAntiForgeryToken]
        [HttpPost("excluir/{CO_PROJETO:int}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int CO_PROJETO)
        {
            await _projetoService.Excluir(CO_PROJETO);
            if (OperacaoValida())
            {
                TempData["Success"] = "Projeto excluído com sucesso.";
                return RedirectToAction(nameof(Index));
            }

            var projeto = await _projetoService.ObterPorId(CO_PROJETO);
            return View(projeto);
        }

        private async Task<SelectList> DropDownTipos()
        {
            var tipos = await _projetoService.ObterTipos();
            return new SelectList(tipos, "CO_TIPO", "DESCRICAO");
        }

        private async Task<SelectList> DropDownTiposEdit(int coProjeto)
        {
            var tipos = await _projetoService.ObterTiposEdit(coProjeto);
            return new SelectList(tipos, "CO_TIPO", "DESCRICAO");
        }

        private async Task<SelectList> DropDownStatus()
        {
            var status = await _projetoService.ObterStatus();
            return new SelectList(status, "CO_STATUS", "DESCRICAO");
        }
        private async Task<SelectList> DropDownProjetos()
        {
            var responsaveis = await _projetoService.ObterProjetos();
            return new SelectList(responsaveis, "CO_PROJETO", "NOME");
        }


        private async Task<SelectList> DropDownResponsaveis(int co_projeto)
        {
            var projetos = await _projetoService.Responsaveis(co_projeto);
            return new SelectList(projetos, "MATRICULA_RESPONSAVEL", "NOME");
        }
        private async Task<SelectList> DropDownProjetosEdit(int coProjeto)
        {
            var projetos = await _projetoService.ObterProjetosEdit(coProjeto);
            return new SelectList(projetos, "CO_PROJETO", "NOME");
        }

        private async Task<SelectList> DropDownStatusEdit(int coProjeto)
        {
            var status = await _projetoService.ObterStatusEdit(coProjeto);
            return new SelectList(status, "CO_STATUS", "DESCRICAO");
        }

        private async Task<SelectList> DropDownGerentes()
        {
            var gerente = await _usuarioService.ObterGerentes();
            return new SelectList(gerente, "Matricula", "NomeEMatricula");
        }


        private async Task<SelectList> DropDownPatrocinadores(string matricula)
        {
            var patrocinador = await _usuarioService.PesquisarUsuarios(matricula);
            return new SelectList(patrocinador, "Matricula", "NomeEMatricula");
        }

        private async Task<SelectList> DropDownComplexidade()
        {
            var listaComplexidade = await _projetoService.ObterComplexidades();
            return new SelectList(listaComplexidade, "CO_COMPLEXIDADE", "COMPLEXIDADE");
        }

        private async Task<SelectList> DropDownComplexidadeEdit(int coProjeto)
        {
            var listaComplexidade = await _projetoService.ObterComplexidadesEdit(coProjeto);
            return new SelectList(listaComplexidade, "CO_COMPLEXIDADE", "COMPLEXIDADE");
        }

        private async Task<SelectList> DropDownCategoria()
        {
            var listaCategoria = await _projetoService.ObterCategorias();
            return new SelectList(listaCategoria, "CO_CATEGORIA", "DESCRICAO");
        }

        private async Task<SelectList> DropDownCategoriaEdit(int coProjeto)
        {
            var listaCAtegoria = await _projetoService.ObterCategoriasEdit(coProjeto);
            return new SelectList(listaCAtegoria, "CO_CATEGORIA", "DESCRICAO");
        }

        private async Task<SelectList> DropDownPrioridades()
        {
            var listaComplexidade = await _projetoService.ObterPrioridades();
            return new SelectList(listaComplexidade, "CO_PRIORIDADE", "PRIORIDADE");
        }
        private async Task<SelectList> DropDownPrioridadesEdit(int coProjeto)
        {
            var listaComplexidade = await _projetoService.ObterPrioridadesEdit(coProjeto);
            return new SelectList(listaComplexidade, "CO_PRIORIDADE", "PRIORIDADE");
        }
        [Breadcrumb("Projetos")]
        [HttpPost("obterusuario")]
        public async Task<JsonResult> ObterUsuario(string matricula)
        {
            return Json(await _usuarioService.ObterUsuarioPorMatricula(matricula.ToUpper()));
        }


        [Breadcrumb("Projetos")]
        [HttpPost("obterUnd")]
        public async Task<JsonResult> ObterUnd(int unidade)
        {
            var und = await _projetoService.ObterUnidadesPorId(unidade);
            return Json(und);
        }

        public string obterCor(DateTime? DataFim, string Status)
        {
            if (Status == "Finalizado") return "#28a745";
            if (Status != "Finalizado" && DataFim <= DateTime.Now) return "#dc3545";
            if (Status != "Finalizado" && DataFim > DateTime.Now) return "#007bff";

            return "Gray";
        }
        [Breadcrumb("Projetos")]
        [HttpPost("marco-relacionado")]
        public async Task<IActionResult> CreateMarcosEntregaRelacionado(int? projeto, int? cgcUnd, int? coProjeto)
        {


            int CO_PROJETO = Convert.ToInt32(projeto);
            var model = new CreateMarcosEntregaRelacionadoViewModel();

            model.filtroDropDown.cgcUnd = cgcUnd;
            model.filtroDropDown.coProjeto = coProjeto;


            var listaMarcos = await _projetoService.ObterListaMarcos();
            listaMarcos = listaMarcos.Where(x => x.IS_ATIVO && x.CO_PROJETO != projeto);
            ViewBag.DropDownUnidades = new SelectList(listaMarcos.Select(x => new { x.CGC_UND, x.SG_SIGLA }).Distinct(), "CGC_UND", "SG_SIGLA");
            ViewBag.DropDownProjetos = new SelectList(listaMarcos.Where(x => x.CGC_UND == cgcUnd || cgcUnd == null).Select(x => new { x.CO_PROJETO, x.NOME_PROJETO }).Distinct(), "CO_PROJETO", "NOME_PROJETO");
            ViewBag.DropDownMarcos = new SelectList(listaMarcos.Where(x => x.CO_PROJETO == coProjeto || coProjeto == null).Select(x => new { x.CO_MARCOS_ENTREGA, x.DESCRICAO }).Distinct(), "CO_MARCOS_ENTREGA", "DESCRICAO");
            ViewBag.DropDownResponsaveis = await DropDownResponsaveis(CO_PROJETO);
            ViewBag.coProjeto = CO_PROJETO;
            return View(model);
        }
        [Breadcrumb("Projetos")]
        [HttpPost("salvar-marco-relacionado")]
        public async Task<IActionResult> SalvarMarco(CreateMarcosEntregaRelacionadoViewModel Viewmodel)
        {

            int CO_PROJETO = Viewmodel.marcosEntregaRelacionadoViewModel.CO_PROJETO;



            await _projetoService.CadastraMarcoRelacionado(Viewmodel.marcosEntregaRelacionadoViewModel);



            var model = new ProjetoViewModel();

            model = await _projetoService.ObterPorId(CO_PROJETO);
            ViewBag.DropDownTipos = await DropDownTiposEdit(CO_PROJETO);
            ViewBag.DropDownStatus = await DropDownStatusEdit(CO_PROJETO);


            ViewBag.Responsavel = await DropDownResponsaveis(CO_PROJETO);
            model.TipoMarcosEntregas = await _parametroService.ObterTipoMarcosEntregas();
            model.StatusAtividadeMarcoEntrega = await _parametroService.ObterStatusAtvidadeMarcosEntrega();
            model.marcosEntregasAtivos = await _projetoService.ObterListaMarcos();


            return View("_MarcosEntregasRelacionado", model);


        }
    }
}