using System.ComponentModel.DataAnnotations;

namespace Core.Business.ViewModels.Projetos
{
    public class BeneficioViewModel
    {
        [Key]
        public int CO_BENEFICIO { get; set; }
        public int CO_PROJETO { get; set; }
        public string DESCRICAO { get; set; }
    }
}