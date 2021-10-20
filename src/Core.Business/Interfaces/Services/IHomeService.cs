using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Core.Business.ViewModels;
using Core.Business.ViewModels.Projetos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces.Services
{
    public interface IHomeService
    {
        Task<Highchart> ObterGraficoPorGerente(DashboardViewModel filtro);
        Task<Highchart> ObterGraficoPorSituacao(DashboardViewModel filtro);
        Task<Highchart> ObterGraficoPorCliente(DashboardViewModel filtro);
        Task<Highchart> ObterGraficoPorCategoria(DashboardViewModel filtro);
        Task<Highchart> ObterGraficoPorDemandante(DashboardViewModel filtro);
        Task<List<ProjetoViewModel>> ObterProjetos(DashboardViewModel filtro);
        Task<List<Dashboard>> ProjetosRelatorio();


    }
}
