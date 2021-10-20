using Core.Business.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Entities.Identity
{
    public class UsuarioVinculado : Entity
    {
        public string MATRICULA_GERENTE { get; set; }
        public string MATRICULA_VINCULO { get; set; }

        // NAVEGACAO
        public Usuario Vinculo { get; set; }
        public UsuarioAcesso UsuarioAcesso { get; set; }
    }
}
