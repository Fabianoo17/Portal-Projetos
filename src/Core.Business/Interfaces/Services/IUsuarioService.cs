using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Core.Business.ViewModels;
using Core.Business.ViewModels.Identity;
using System.Collections.Generic;
using Core.Business.Entities.Identity;
using System.Security.Claims;

namespace Core.Business.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioViewModel> ObterUsuarioPorMatricula(string matricula);
        Task<IEnumerable<UsuarioViewModel>> PesquisarUsuarios(string nomeOuMatricula);
        Task<IEnumerable<UsuarioAcessoViewModel>> ObterUsuariosAcesso();
        Task<IEnumerable<PerfilViewModel>> ObterPerfis();
        Task Cadastrar(UsuarioAcessoCreateEditViewModel viewModel);
        Task<UsuarioAcessoViewModel> ObterUsuarioAcessoPorMatricula(string matricula);
        Task Atualizar(UsuarioAcessoCreateEditViewModel viewModel);
        Task Excluir(string matricula);
        Task<List<Claim>> ObterClaims(string matricula);
        Task<IEnumerable<UsuarioViewModel>> ObterGerentes();

        Task<UsuarioVinculadoViewModel> ObterVinculosPorGerente(string matricula);
        Task<IEnumerable<UsuarioViewModel>> ObterUsuariosVinculadosPorGerente(string matricula);
        Task AtualizarVinculacao(UsuarioVinculadoViewModel viewModel);
    }
}