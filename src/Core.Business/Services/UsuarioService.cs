using AutoMapper;
using Core.Business.Entities.Identity;
using Core.Business.EntitiesValidations;
using Core.Business.Interfaces;
using Core.Business.Interfaces.Repositories.Identity;
using Core.Business.Interfaces.Services;
using Core.Business.ViewModels.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioAcessoRepository _usuarioAcessoRepository;
        private readonly IDadosADRepository _dadosADRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public UsuarioService(INotificador notificador,
                              IUsuarioRepository usuarioRepository,
                              IMapper mapper,
                              IUsuarioAcessoRepository usuarioAcessoRepository,
                              IUser user,
                              IDadosADRepository dadosADRepository,
                              IMemoryCache cache) : base(notificador, user)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _usuarioAcessoRepository = usuarioAcessoRepository;
            _dadosADRepository = dadosADRepository;
            _cache = cache;
        }

        public async Task<IEnumerable<PerfilViewModel>> ObterPerfis()
        {
            var perfis = await _usuarioAcessoRepository.ObterPerfis();
            return _mapper.Map<IEnumerable<PerfilViewModel>>(perfis);
        }

        public async Task<UsuarioViewModel> ObterUsuarioPorMatricula(string matricula)
        {
            var model = await _usuarioRepository.GetAsync(x => x.Matricula == matricula && x.FLAG_ATIVO);
            return _mapper.Map<UsuarioViewModel>(model);
        }

        public async Task<IEnumerable<UsuarioViewModel>> PesquisarUsuarios(string nomeOuMatricula)
        {
            var model = await _usuarioRepository.PesquisarUsuarios(nomeOuMatricula);

            if (!model.Any())
            {
                var model2 = await _dadosADRepository.PesquisarUsuarios(nomeOuMatricula);
                return _mapper.Map<IEnumerable<UsuarioViewModel>>(model2);
            }

            return _mapper.Map<IEnumerable<UsuarioViewModel>>(model);
        }

        public async Task<IEnumerable<UsuarioAcessoViewModel>> ObterUsuariosAcesso()
        {
            var model = await _usuarioAcessoRepository.ObterUsuariosAcesso();
            return _mapper.Map<IEnumerable<UsuarioAcessoViewModel>>(model);
        }

        public async Task Cadastrar(UsuarioAcessoCreateEditViewModel viewModel)
        {
            try
            {
                var usuarioAcesso = new UsuarioAcesso
                {
                    MATRICULA = viewModel.Matricula,
                    UsuariosPerfis = viewModel.Perfis.Select(x => new UsuarioPerfil { MATRICULA = viewModel.Matricula, PERFIL_ID = x }).ToList()
                };

                if (!ExecutarValidacao(new UsuarioAcessoValidation(), usuarioAcesso))
                    return;

                if (await _usuarioAcessoRepository.ExistsAsync(x => x.MATRICULA == viewModel.Matricula))
                {
                    Notificar("Usuário já cadastrado");
                    return;
                }

                await _usuarioAcessoRepository.CreateAsync(usuarioAcesso);
                LimparCacheUsuario(viewModel.Matricula);
            }
            catch (Exception ex)
            {
                Notificar(ex.Message);
            }
        }

        public async Task<UsuarioAcessoViewModel> ObterUsuarioAcessoPorMatricula(string matricula)
        {
            var model = await _usuarioAcessoRepository.GetAsync(x => x.MATRICULA == matricula,
                new List<Expression<Func<UsuarioAcesso, object>>>
                {
                    p=> p.UsuariosPerfis,
                    u=> u.Usuario
                });

            return _mapper.Map<UsuarioAcessoViewModel>(model);
        }

        public async Task Atualizar(UsuarioAcessoCreateEditViewModel viewModel)
        {
            try
            {
                var usuarioAcesso = new UsuarioAcesso
                {
                    MATRICULA = viewModel.Matricula,
                    UsuariosPerfis = viewModel.Perfis.Select(x => new UsuarioPerfil { MATRICULA = viewModel.Matricula, PERFIL_ID = x }).ToList()
                };

                if (!ExecutarValidacao(new UsuarioAcessoValidation(), usuarioAcesso))
                    return;

                await _usuarioAcessoRepository.AtualizarUsuario(usuarioAcesso);
                LimparCacheUsuario(viewModel.Matricula);
            }
            catch (Exception ex)
            {
                Notificar(ex.Message);
            }
        }

        public async Task Excluir(string matricula)
        {
            try
            {
                await _usuarioAcessoRepository.ExcluirUsuario(matricula);
                LimparCacheUsuario(matricula);
            }
            catch (Exception ex)
            {
                Notificar(ex.Message);
            }
        }

        public async Task<List<Claim>> ObterClaims(string matricula)
        {
            var claims = new List<Claim>();
            var usuarioAcesso = await ObterUsuarioAcessoPorMatricula(matricula);
            if (usuarioAcesso != null)
            {
                List<int> perfis = usuarioAcesso.UsuariosPerfis.Select(x => x.PERFIL_ID).ToList();
                perfis.Add((int)EPerfil.Leitor);

                claims = new List<Claim> {
                    new Claim("Nome", usuarioAcesso.Usuario.Nome),
                    new Claim("Matricula", usuarioAcesso.Usuario.Matricula),
                    new Claim("UnidadeNome", usuarioAcesso.Usuario.NomeUnidade),
                    new Claim("UnidadeCodigo", usuarioAcesso.Usuario.CodigoUnidade),
                    new Claim("Perfis", string.Join(",", perfis))
                };
            }
            else
            {
                // Adiciona perfil de leitura para todos usuarios
                var usuario = await ObterUsuarioPorMatricula(matricula);

                claims = new List<Claim> {
                    new Claim("Nome", usuario.Nome),
                    new Claim("Matricula", usuario.Matricula),
                    new Claim("UnidadeNome", usuario.NomeUnidade),
                    new Claim("UnidadeCodigo", usuario.CodigoUnidade),
                    new Claim("Perfis", string.Join(",", new List<int>{ (int)EPerfil.Leitor }))
                };
            }

            return claims;
        }

        public async Task<UsuarioVinculadoViewModel> ObterVinculosPorGerente(string matricula)
        {
            var usuarioAcesso = await _usuarioAcessoRepository.ObterUsuarioAcessoComVinculos(matricula);
            if (usuarioAcesso != null)
            {
                return new UsuarioVinculadoViewModel
                {
                    MATRICULA_GERENTE = usuarioAcesso.Usuario.Matricula,
                    NOME_GERENTE = usuarioAcesso.Usuario.Nome,
                    MatriculasVinculadas = usuarioAcesso.UsuariosVinculados.Select(x => x.MATRICULA_VINCULO).ToList()
                };
            }
            return null;
        }

        public async Task<IEnumerable<UsuarioViewModel>> ObterUsuariosVinculadosPorGerente(string matricula)
        {
            var usuarioAcesso = await _usuarioAcessoRepository.ObterUsuarioAcessoComVinculos(matricula);
            if (usuarioAcesso != null)
            {
                var usuariosVinculados = usuarioAcesso.UsuariosVinculados.Select(x => x.Vinculo).ToList();
                return _mapper.Map<IEnumerable<UsuarioViewModel>>(usuariosVinculados);
            }

            return null;
        }

        public async Task<IEnumerable<UsuarioViewModel>> ObterGerentes()
        {
            var usuarioAcessos = await _usuarioAcessoRepository.ObterUsuariosAcesso();

            var gerentes = usuarioAcessos
                .Where(x => x.UsuariosPerfis.Any(y => y.PERFIL_ID == (int)EPerfil.Gerente))
                .Select(x => x.Usuario)
                .ToList();

            return _mapper.Map<IEnumerable<UsuarioViewModel>>(gerentes);
        }

        public async Task AtualizarVinculacao(UsuarioVinculadoViewModel viewModel)
        {
            try
            {
                var usuarioAcesso = await _usuarioAcessoRepository.ObterUsuarioAcessoComVinculos(viewModel.MATRICULA_GERENTE);
                if (usuarioAcesso == null)
                {
                    Notificar("Gerente não informado.");
                    return;
                }

                usuarioAcesso.UsuariosVinculados.Clear();

                var novosVinculos = viewModel.MatriculasVinculadas.Select(x => new UsuarioVinculado { MATRICULA_GERENTE = viewModel.MATRICULA_GERENTE, MATRICULA_VINCULO = x }).ToList();
                usuarioAcesso.UsuariosVinculados = novosVinculos;
                await _usuarioAcessoRepository.UpdateAsync(usuarioAcesso);
            }
            catch (Exception ex)
            {
                Notificar(ex.Message);
            }
        }

        private void LimparCacheUsuario(string key)
        {
            _cache.Remove(key.ToUpper());
        }
    }
}