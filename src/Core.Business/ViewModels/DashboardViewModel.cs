using Core.Business.Entities;
using Core.Business.ViewModels.Projetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.ViewModels
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            GraficosDashboard = new List<Highchart>();
            Projetos = new List<ProjetoViewModel>();

        }

        public List<Highchart> GraficosDashboard;
        public List<ProjetoViewModel> Projetos;


        public string[] Demandante { get; set; }
        public string[] Gerente { get; set; }
        public int?[] Tipo { get; set; }
        public int?[] Situacao { get; set; }
        public int?[] Categoria { get; set; }
    }
}
