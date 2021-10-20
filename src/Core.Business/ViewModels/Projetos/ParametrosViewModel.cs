using System.Collections.Generic;

namespace Core.Business.ViewModels.Projetos
{
    public class ParametrosViewModel
    {
        public ParametrosViewModel()
        {
            Complexidades = new List<ComplexidadeProjetoViewModel>();
            Prioridades = new List<PrioridadeProjetoViewModel>();
            Status = new List<StatusProjetoViewModel>();
            TiposProjeto = new List<TipoProjetoViewModel>();
            Categorias = new List<CategoriaViewModel>();
            TiposEntregas = new List<TipoMarcosEntregasViewModels>();
            StatusAtividadesEntrega = new List<StatusAtividadeMarcoEntregaViewModel>();

        }

        public IEnumerable<ComplexidadeProjetoViewModel> Complexidades { get; set; }
        public IEnumerable<PrioridadeProjetoViewModel> Prioridades { get; set; }
        public IEnumerable<StatusProjetoViewModel> Status { get; set; }
        public IEnumerable<TipoProjetoViewModel> TiposProjeto { get; set; }
        public IEnumerable<CategoriaViewModel> Categorias { get; set; }
        public IEnumerable<TipoMarcosEntregasViewModels> TiposEntregas { get; set; }
        public IEnumerable<StatusAtividadeMarcoEntregaViewModel> StatusAtividadesEntrega { get; set; }
    }
}
