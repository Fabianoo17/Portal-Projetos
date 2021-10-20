using Core.Business.ViewModels.Projetos;

namespace Core.Web.Models
{
    public class CreateMarcosEntregaRelacionadoViewModel
    {
        public CreateMarcosEntregaRelacionadoViewModel()
        {
            filtroDropDown = new FiltroDropDown();
            marcosEntregaRelacionadoViewModel = new MarcosEntregaRelacionadoViewModel();
        }
        public FiltroDropDown filtroDropDown { get; set; }
        public MarcosEntregaRelacionadoViewModel marcosEntregaRelacionadoViewModel { get; set; }

    }
}
