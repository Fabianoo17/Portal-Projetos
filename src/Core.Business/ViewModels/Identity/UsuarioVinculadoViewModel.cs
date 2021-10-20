using Core.Business.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Business.ViewModels.Identity
{
    public class UsuarioVinculadoViewModel
    {
        public UsuarioVinculadoViewModel()
        {
            MatriculasVinculadas = new HashSet<string>();
        }

        public string MATRICULA_GERENTE { get; set; }

        [Display(Name = "Gerente")]
        public string NOME_GERENTE { get; set; }

        [Display(Name = "Vínculos")]
        public ICollection<string> MatriculasVinculadas { get; set; }
    }
}
