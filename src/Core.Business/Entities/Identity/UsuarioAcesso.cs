using System.Collections.Generic;

namespace Core.Business.Entities.Identity
{
    public class UsuarioAcesso : Entity
    {
        public UsuarioAcesso()
        {
            UsuariosPerfis = new HashSet<UsuarioPerfil>();
            UsuariosVinculados = new HashSet<UsuarioVinculado>();
        }

        public string MATRICULA { get; set; }

        // NAVEGAÇÃO
        public ICollection<UsuarioPerfil> UsuariosPerfis { get; set; }
        public ICollection<UsuarioVinculado> UsuariosVinculados { get; set; }
        public Usuario Usuario { get; set; }
    }
}