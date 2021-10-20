using AutoMapper;
using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Core.Business.Interfaces;
using Core.Business.Interfaces.Repositories;
using Core.Business.Interfaces.Services;
using Core.Business.ViewModels;
using Core.Business.ViewModels.Projetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Business.Services
{
    public class HomeService : BaseService, IHomeService
    {
        IDashboardRepository _Dashboard;
        IProjetoRepository _Projeto;
        IMapper _mapper;
        public HomeService(INotificador notificador,
                           IUser user,
                           IDashboardRepository Dashboard,
                           IProjetoRepository Projeto,
                           IMapper mapper ) : base(notificador, user)
        {
            _Dashboard = Dashboard;
            _Projeto = Projeto;
            _mapper = mapper;
        }
        public async Task<Highchart> ObterGraficoPorGerente(DashboardViewModel filtro)
        {
        
            var Lista = await _Dashboard.GetManyAsync(x => x.CGC_UND == Convert.ToInt32(UserCustom.UnidadeCodigo) 
            && (filtro.Tipo.Contains(x.CO_TIPO) || filtro.Tipo == null)
            && (filtro.Categoria.Contains(x.CO_CATEGORIA) || filtro.Categoria == null)
            && (filtro.Situacao.Contains(x.CO_STATUS) || filtro.Situacao == null)
            && (filtro.Gerente.Contains(x.MATRICULA_GERENTE) || filtro.Gerente == null)
            && (filtro.Demandante.Contains(x.GESTOR_DEMANDANTE) || filtro.Demandante == null)
            );

            Highchart GraficoGerente = new Highchart();
            GraficoGerente.title = "Gerentes";
            GraficoGerente.categories = Lista.OrderBy(x=> x.NOME_GERENTE).Select(x => x.NOME_GERENTE).Distinct().ToList();
            SeriesHighchart seriesGerente = new SeriesHighchart();
            seriesGerente.name = "Projetos";
            foreach (var item in GraficoGerente.categories)
            {
                seriesGerente.data.Add(Lista.Count(x => x.NOME_GERENTE == item));
            }
            GraficoGerente.series.Add(seriesGerente);
            return GraficoGerente;

        }
        public async Task<Highchart> ObterGraficoPorCategoria(DashboardViewModel filtro)
        {
            var Lista = await _Dashboard.GetManyAsync(x => x.CGC_UND == Convert.ToInt32(UserCustom.UnidadeCodigo) &&
                (filtro.Tipo.Contains(x.CO_TIPO) || filtro.Tipo == null)
                && (filtro.Categoria.Contains(x.CO_CATEGORIA) || filtro.Categoria == null)
                && (filtro.Situacao.Contains(x.CO_STATUS) || filtro.Situacao == null)
                && (filtro.Gerente.Contains(x.MATRICULA_GERENTE) || filtro.Gerente == null)
                && (filtro.Demandante.Contains(x.GESTOR_DEMANDANTE) || filtro.Demandante == null)
                );


            Highchart GraficoCategoria = new Highchart();
            GraficoCategoria.title = "Categorias";
            GraficoCategoria.labels = Lista.Select(x => x.DESCRICAO_CATEGORIA).Distinct().ToList();

            foreach (var item in GraficoCategoria.labels)
            {
                PieData pie = new PieData();
                pie.name = item;
                pie.y = Lista.Count(x => x.DESCRICAO_CATEGORIA == item);
                GraficoCategoria.pies.Add(pie);
            }

            return GraficoCategoria;
        }

        public async Task<Highchart> ObterGraficoPorDemandante(DashboardViewModel filtro)
        {
            var Lista = await _Dashboard.GetManyAsync(x => x.CGC_UND == Convert.ToInt32(UserCustom.UnidadeCodigo) &&
                (filtro.Tipo.Contains(x.CO_TIPO) || filtro.Tipo == null)
                && (filtro.Categoria.Contains(x.CO_CATEGORIA) || filtro.Categoria == null)
                && (filtro.Situacao.Contains(x.CO_STATUS) || filtro.Situacao == null)
                && (filtro.Gerente.Contains(x.MATRICULA_GERENTE) || filtro.Gerente == null)
                && (filtro.Demandante.Contains(x.GESTOR_DEMANDANTE) || filtro.Demandante == null)
                );

            Highchart GraficoDemandate = new Highchart();
            GraficoDemandate.title = "Demandates";
            GraficoDemandate.categories = Lista.OrderBy(x => x.NOME_DEMANDANTE).Select(x => x.NOME_DEMANDANTE).Distinct().ToList();
            SeriesHighchart seriesDemandante = new SeriesHighchart();
            seriesDemandante.name = "Projetos";
            foreach (var item in GraficoDemandate.categories)
            {
                seriesDemandante.data.Add(Lista.Count(x => x.NOME_DEMANDANTE == item));
            }
            GraficoDemandate.series.Add(seriesDemandante);
            return GraficoDemandate;
        }

        public async Task<Highchart> ObterGraficoPorSituacao(DashboardViewModel filtro)
        {

            var Lista = await _Dashboard.GetManyAsync(x => x.CGC_UND == Convert.ToInt32(UserCustom.UnidadeCodigo) &&
            (filtro.Tipo.Contains(x.CO_TIPO) || filtro.Tipo == null)
            && (filtro.Categoria.Contains(x.CO_CATEGORIA) || filtro.Categoria == null)
            && (filtro.Situacao.Contains(x.CO_STATUS) || filtro.Situacao == null)
            && (filtro.Gerente.Contains(x.MATRICULA_GERENTE) || filtro.Gerente == null)
            && (filtro.Demandante.Contains(x.GESTOR_DEMANDANTE) || filtro.Demandante == null)
            );

            Highchart GraficoSituacao = new Highchart();
            GraficoSituacao.title = "Situações";
            GraficoSituacao.labels = Lista.Select(x => x.DESCRICAO_STATUS).Distinct().ToList();
          
            foreach (var item in GraficoSituacao.labels)
            {
                PieData pie = new PieData();
                pie.name = item;
                pie.y = Lista.Count(x => x.DESCRICAO_STATUS == item);
                GraficoSituacao.pies.Add(pie);
            }
          
            return GraficoSituacao;

        }

        public async Task<Highchart> ObterGraficoPorCliente(DashboardViewModel filtro)
        {

            var Lista = await _Dashboard.GetManyAsync(x => x.CGC_UND == Convert.ToInt32(UserCustom.UnidadeCodigo) &&
                (filtro.Tipo.Contains(x.CO_TIPO) || filtro.Tipo == null)
                && (filtro.Categoria.Contains(x.CO_CATEGORIA) || filtro.Categoria == null)
                && (filtro.Situacao.Contains(x.CO_STATUS) || filtro.Situacao == null)
                && (filtro.Gerente.Contains(x.MATRICULA_GERENTE) || filtro.Gerente == null)
                && (filtro.Demandante.Contains(x.GESTOR_DEMANDANTE) || filtro.Demandante == null)
                );

            Highchart GraficoDemandantes = new Highchart();
            GraficoDemandantes.title = "Clientes";
            GraficoDemandantes.categories = Lista.OrderBy(x=> x.DESCRICAO_TIPO).Select(x => x.DESCRICAO_TIPO).Distinct().ToList();
            SeriesHighchart SeriesDemandates = new SeriesHighchart();
            foreach (var item in GraficoDemandantes.categories)
            {
                SeriesDemandates.data.Add(Lista.Count(x => x.DESCRICAO_TIPO == item));
            }
            GraficoDemandantes.series.Add(SeriesDemandates);
            return GraficoDemandantes;

        }

        public async Task<List<ProjetoViewModel>> ObterProjetos(DashboardViewModel filtro)
        {
            var model = await _Projeto.GetAllAsync();

            var Lista = model.Where(x => x.CGC_UND == Convert.ToInt32(UserCustom.UnidadeCodigo) &&
                (filtro.Tipo.Contains(x.CO_TIPO) || filtro.Tipo == null)
                && (filtro.Categoria.Contains(x.CO_CATEGORIA) || filtro.Categoria == null)
                && (filtro.Situacao.Contains(x.CO_STATUS) || filtro.Situacao == null)
                && (filtro.Gerente.Contains(x.MATRICULA_GERENTE) || filtro.Gerente == null)
                && (filtro.Demandante.Contains(x.GESTOR_DEMANDANTE) || filtro.Demandante == null)
                );
            return  _mapper.Map<List<ProjetoViewModel>>(Lista);
        }


        public async Task<List<Dashboard>> ProjetosRelatorio()
        {
            var model = await _Dashboard.GetAllAsync();
            return model.Where(x=>x.CGC_UND == Convert.ToInt32(UserCustom.UnidadeCodigo)).ToList();
        }


    }
}
