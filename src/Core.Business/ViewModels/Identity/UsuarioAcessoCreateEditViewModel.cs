using System.ComponentModel.DataAnnotations;

namespace Core.Business.ViewModels.Identity
{
    public class UsuarioAcessoCreateEditViewModel
    {
        private string matricula;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Matrícula")]
        public string Matricula
        {
            get { return matricula.ToUpper(); }
            set { matricula = value; }
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int[] Perfis { get; set; }
    }
}