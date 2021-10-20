namespace Core.Business.ViewModels.Projetos
{
    public class TipoMarcosEntregasViewModels
    {
        public TipoMarcosEntregasViewModels()
        {
            IS_ATIVO = true;
        }
        
        public int CO_TIPO_MARCOS_ENTREGA { get; set; }
        public string NOME { get; set; }
        public bool IS_ATIVO { get; set; }
    }
}
