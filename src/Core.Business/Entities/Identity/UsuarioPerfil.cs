namespace Core.Business.Entities.Identity
{
    public class UsuarioPerfil : Entity
    {
        public string MATRICULA { get; set; }
        public int PERFIL_ID { get; set; }

        // NAVEGAÇÃO
        public UsuarioAcesso UsuarioAcesso { get; set; }
        public Perfil Perfil { get; set; }
    }
}