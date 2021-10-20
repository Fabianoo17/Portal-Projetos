using Core.Business.Entities;
using Core.Business.ViewModels.Projetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.ViewModels
{
    public class ParametroViewModel
    {
        public ParametroViewModel()
        {
            GraficosDashboard = new List<Highchart>();
            Projetos = new List<ProjetoViewModel>();

        }
        public List<Highchart> GraficosDashboard;
        public List<ProjetoViewModel> Projetos;
    }
}
