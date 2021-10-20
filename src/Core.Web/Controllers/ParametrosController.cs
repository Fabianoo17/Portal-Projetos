using Core.Business.Interfaces;
using Core.Business.Interfaces.Services;
using Core.Business.ViewModels;
using Core.Business.ViewModels.Identity;
using Core.Business.ViewModels.Projetos;
using Core.Web.Security;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core.Web.Controllers
{
    [CustomAuthorize(new[] { EPerfil.Administrador, EPerfil.Leitor, EPerfil.Gerente })]
    public class ParametrosController : MainController
    {

        private readonly IParametroService _parametro;
        public ParametrosController(IParametroService parametro,
                                    INotificador notificador,
                                    IUser user) : base(notificador, user)
        {
            _parametro = parametro;
        }
        public async Task<IActionResult> Index()
        {
            var ParametrosModel = await _parametro.ObterParametros();
            return View(ParametrosModel);
        }

        public async Task<IActionResult> AtualizarComplexidade(ComplexidadeProjetoViewModel model)
        {
            if (model.CO_COMPLEXIDADE == 0)
            {
                if (!await _parametro.ComplexidadeExiste(model.COMPLEXIDADE)) {
                    await _parametro.AdicionarComplexidade(model);
                    TempData["MSG_SUCESS"] = "Nível de Complexidade adicionado com sucesso.";
                    TempData["DDL_SELECT"] = "divComplexidade";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MSG_ERROR"] = "Nível de Complexidade informada já existe.";
                    TempData["DDL_SELECT"] = "divComplexidade";
                    return RedirectToAction("Index");
                }


            }
            else
            {
                await _parametro.AtualizarComplexidade(model);
                var mensagem = "Nível de Complexidade atualizado com sucesso.";
                return CustomResponse(new { mensagem });
            }
        }

        public async Task<IActionResult> AtualizarPrioridade(PrioridadeProjetoViewModel model)
        {
            if (model.CO_PRIORIDADE == 0)
            {
                await _parametro.AdicionaPrioridade(model);
                TempData["MSG_SUCESS"] = "Nível de Prioridade adicionado com sucesso.";
                TempData["DDL_SELECT"] = "divPrioridade";
                return RedirectToAction("Index");
            }
            else
            {
                var mensagem = "Nível de Prioridade atualizado com sucesso.";
                await _parametro.AtualizarPrioridade(model);
                return CustomResponse(new { mensagem });
            }
        }

        public async Task<IActionResult> AtualizarTipoProjeto(TipoProjetoViewModel model)
        {
            if (model.CO_TIPO == 0)
            {
                await _parametro.AdicionarTipoProjeto(model);
                TempData["MSG_SUCESS"] = "Tipo de Projeto adicionado com sucesso.";
                TempData["DDL_SELECT"] = "divTipoProjeto";
                return RedirectToAction("Index");
            }
            else
            {
                await _parametro.AtualizarTipoProjeto(model);
                var mensagem = "Tipo de Projeto atualizado com sucesso.";
                return CustomResponse(new { mensagem });

            }
        }

        public async Task<IActionResult> AtualizarStatusProjeto(StatusProjetoViewModel model)
        {
            if (model.CO_STATUS == 0)
            {
                await _parametro.AdcionarStatusProjeto(model);
                TempData["MSG_SUCESS"] = "Status de Projeto adicionado com sucesso.";
                TempData["DDL_SELECT"] = "divStatusProjeto";
                return RedirectToAction("Index");
            }
            else {
                await _parametro.AtualizarStatusProjeto(model);
                var mensagem = "Status de Projeto atualizado com sucesso.";
                return CustomResponse(new { mensagem });
            }
        }

        public async Task<IActionResult> AtualizarCategoria(CategoriaViewModel model)
        {
            if (model.CO_CATEGORIA == 0)
            {
                await _parametro.AdicionarCategoria(model);
                TempData["MSG_SUCESS"] = "Categoria de Projeto adicionado com sucesso.";
                TempData["DDL_SELECT"] = "divCategoriaProjeto";
                return RedirectToAction("Index");
            }
            else
            {
                await _parametro.AtualizarCategoria(model);
                var mensagem = "Categoria de Projeto atualizado com sucesso.";
                return CustomResponse(new { mensagem });
            }
        }

        public async Task<IActionResult> AtualizarTipoEntrega(TipoMarcosEntregasViewModels model)
        {
            if (model.CO_TIPO_MARCOS_ENTREGA == 0)
            {
                await _parametro.AdicionarTipoMarcosEntregas(model);
                TempData["MSG_SUCESS"] = "Tipo de Marcos Entregas adicionado com sucesso.";
                TempData["DDL_SELECT"] = "divTipoMarcosEntregas";
                return RedirectToAction("Index");
            }
            else
            {
                await _parametro.AtualizarTipoMarcosEntregas(model);
                var mensagem = "Tipo de Marcos Entregas atualizado com sucesso.";
                return CustomResponse(new { mensagem });
            }
        }

        public async Task<IActionResult> AtualizarStatusAtividadeMarcoEntrega(StatusAtividadeMarcoEntregaViewModel model)
        {
            if (model.CO_STATUS_ATIVIDADE_MARCO_ENTREGA == 0)
            {
                await _parametro.AdicionarStatusAtividadeEntrega(model);
                TempData["MSG_SUCESS"] = "Status da atividade adicionado com sucesso.";
                TempData["DDL_SELECT"] = "divStatusAtividadeMarcosEntrega";
                return RedirectToAction("Index");
            }
            else
            {
                await _parametro.AtualizarStatusAtividadeEntrega(model);
                var mensagem = "Status de Atividade atualizado com sucesso.";
                return CustomResponse(new { mensagem });
            }
        }







        public async Task<bool> ComplexidadeExiste(int complexidade)
        {
            var result = await _parametro.ComplexidadeExiste(complexidade);
            return result;
        }

        public async Task<bool> TipoMarcosEntregasExiste(string tipo)
        {
            var result = await _parametro.TipoMarcosEntregasExiste(tipo);
            return result;
        }

        public async Task<bool> PrioridadeExiste(int prioridade)
        {
            var result = await _parametro.PrioridadeExiste(prioridade);
            return result;
        }

        public async Task<bool> TipoProjetoExiste(string tipoProjeto)
        {
            var result = await _parametro.TipoProjetoExiste(tipoProjeto);
            return result;
        }

        public async Task<bool> StatusProjetoExiste(string statusProjeto)
        {
            var result = await _parametro.StatusProjetoExiste(statusProjeto);
            return result;
        }

        public async Task<bool> CategoriaProjetoExiste(string categoria)
        {
            var result = await _parametro.CategoriaProjetoExiste(categoria);
            return result;
        }

        public async Task<bool> StatusAtividadeMarcosEntregaExiste(string statusAtvidade)
        {
            var result = await _parametro.StatusAtividadeEntregaExiste(statusAtvidade);
            return result;
        }



    }
}