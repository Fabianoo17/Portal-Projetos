using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Business.ViewModels.Identity
{
    public class UsuarioViewModel
    {
        public string Matricula { get; set; }
        [Display(Name="Gerente")]
        public string Nome { get; set; }
        public string CodigoUnidade { get; set; }
        public string NomeUnidade { get; set; }
        public string SiglaUnidade { get; set; }
        public string Funcao { get; set; }
        public string NomeEMatricula { get { return $"{Nome} - {Matricula}"; } }
        public UsuarioAcessoViewModel UsuarioAcesso { get; set; }
    }
}