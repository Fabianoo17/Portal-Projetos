using Core.Business.ViewModels.Projetos;
using System.Collections.Generic;

namespace Core.Business.Entities
{
    public class Highchart
    {
        public Highchart()
        {
            categories = new List<string>();
            series = new List<SeriesHighchart>();
            pies = new List<PieData>();
            data = new List<double>();
            projetos = new List<ProjetoViewModel>();
        }
        public string title { get; set; }
        public List<string> categories { get; set; }
        public List<string> labels { get; set; }
        public List<double> data { get; set; }
        public List<SeriesHighchart> series { get; set; }
        public List<PieData> pies { get; set; }
        public List<ProjetoViewModel> projetos { get; set; }
    }
}
