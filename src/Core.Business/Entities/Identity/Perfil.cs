using System.Collections.Generic;

namespace Core.Business.Entities.Identity
{
    public class Perfil : Entity
    {
        public int PERFIL_ID { get; set; }
        public string NOME { get; set; }

        // Navegação
        public ICollection<UsuarioPerfil> UsuarioPerfis { get; set; }
    }
}