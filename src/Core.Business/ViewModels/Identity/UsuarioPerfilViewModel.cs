namespace Core.Business.ViewModels.Identity
{
    public class UsuarioPerfilViewModel
    {
        public string MATRICULA { get; set; }
        public int PERFIL_ID { get; set; }

        // Navegação
        public PerfilViewModel Perfil { get; set; }
    }
}