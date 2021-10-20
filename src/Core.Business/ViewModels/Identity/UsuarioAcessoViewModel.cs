using System.Collections.Generic;
using Core.Business.Entities.Identity;
using Core.Business.ViewModels.Identity;

namespace Core.Business.ViewModels.Identity
{
    public class UsuarioAcessoViewModel
    {
        public string Matricula { get; set; }

        public ICollection<UsuarioPerfilViewModel> UsuariosPerfis { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}