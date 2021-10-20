using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.ViewModels.Projetos
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel()
        {
            IS_ATIVO = true;
        }
        public int CO_CATEGORIA { get; set; }
        public string DESCRICAO { get; set; }
        public bool IS_ATIVO { get; set; }
    }
}
