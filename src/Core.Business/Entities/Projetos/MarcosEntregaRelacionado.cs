using Core.Business.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Core.Business.Entities.Projetos
{
    public class MarcosEntregaRelacionado : Entity
    {
        public int CO_PROJETO { get; set; }
        public int CO_MARCOS_ENTREGA { get; set; }
        public string NOTA { get; set; }
        public string MAT_RESPONSAVEL { get; set; }
        public DateTime DT_CRIACAO { get; set; }
        public string MAT_CRIADOR{ get; set; }

        public MarcosEntrega MarcosEntrega { get; set; }
        public Projeto Projeto { get; set;}
        public Usuario Responsavel { get; set; }
        public ICollection<AtividadesEntrega> AtividadesEntregas { get; set; }

    }
}
