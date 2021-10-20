using System.Collections.Generic;
using Core.Business.Entities.Projetos;

namespace Core.Business.Entities.Identity
{
    public class Usuario : Entity
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public int? CodigoUnidade { get; set; }
        public string NomeUnidade { get; set; }
        public string SiglaUnidade { get; set; }
        public string Funcao { get; set; }
        public bool FLAG_ATIVO { get; set; }

        // Navegação
        public ICollection<UsuarioAcesso> UsuariosAcesso { get; set; }
        public ICollection<Projeto> ProjetosPatrocinador { get; set; }
        public ICollection<Projeto> ProjetosGerente { get; set; }
        public ICollection<Projeto> ProjetosDemandante { get; set; }
        public ICollection<Apoio> EquipeApoio { get; set; }
        public ICollection<MarcosEntrega> Entregas { get; set; }
        public ICollection<MarcosEntregaRelacionado> EntregasRelacionadas { get; set; }
        public ICollection<UsuarioVinculado> UsuariosVinculados { get; set; }
    }
}