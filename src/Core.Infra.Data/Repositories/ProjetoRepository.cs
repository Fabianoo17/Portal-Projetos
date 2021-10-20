using Core.Business.Entities;
using Core.Business.Entities.Projetos;
using Core.Business.Enums;
using Core.Business.Interfaces.Repositories;
using Core.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infra.Data.Repositories
{
    public class ProjetoRepository : EFRepositoryBase<Projeto, DefaultDbContext>, IProjetoRepository
    {
        public ProjetoRepository(DefaultDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task AddSubItens<T>(IEnumerable<T> itens) where T : Entity
        {
            DbContext.Set<T>().AddRange(itens);
            await DbContext.SaveChangesAsync();
        }

        public bool PossuiAcessoAoProjeto(int projetoId, string matricula)
        {
            return Entity.Any(p => p.CO_PROJETO == projetoId &&
                (p.MATRICULA_GERENTE == matricula ||
                DbContext.UsuariosAcesso.Any(u => u.UsuariosVinculados.Any(v => v.MATRICULA_VINCULO == matricula && v.MATRICULA_GERENTE == p.MATRICULA_GERENTE))));
        }

        public async Task RemoverProjetoESubItensAsync(int projetoId)
        {
            var projeto = await Entity
                .Include(x => x.Objetivos)
                .Include(x => x.Custos)
                .Include(x => x.Justificativas)
                .Include(x => x.Restricoes)
                .Include(x => x.Riscos)
                .Include(x => x.Escopos)
                .Include(x => x.NaoEscopos)
                .Include(x => x.Requisitos)
                .Include(x => x.Beneficios)
                .Include(x => x.Premissas)
                .Include(x => x.MarcosEntregas)
                .Include(x => x.Arquivos)
                .FirstOrDefaultAsync(x => x.CO_PROJETO == projetoId);

            projeto.Objetivos.Clear();
            projeto.Escopos.Clear();
            projeto.NaoEscopos.Clear();
            projeto.Requisitos.Clear();
            projeto.Custos.Clear();
            projeto.Justificativas.Clear();
            projeto.Restricoes.Clear();
            projeto.Riscos.Clear();
            projeto.Beneficios.Clear();
            projeto.Premissas.Clear();
            projeto.MarcosEntregas.Clear();
            projeto.Arquivos.Clear();

            Entity.Remove(projeto);
            await DbContext.SaveChangesAsync();
        }

        public async Task RemoverSubItens<T>(IEnumerable<T> itens) where T : Entity
        {
            DbContext.Set<T>().RemoveRange(itens);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<int>> ObterIdsProjetoPorMembro(string matricula)
        {
            return await Entity
                .Where(p => p.MATRICULA_GERENTE == matricula ||
                    DbContext.UsuariosAcesso.Any(u => u.UsuariosVinculados.Any(v => v.MATRICULA_VINCULO == matricula && v.MATRICULA_GERENTE == p.MATRICULA_GERENTE)))
                .Select(x => x.CO_PROJETO)
                .ToListAsync();
        }

        public async Task<Projeto> ObterPorIdComIncludes(int projetoId)
        {
            var list = await Entity.Include(i => i.Objetivos)
                             .Include(i => i.Custos)
                             .Include(i => i.Justificativas)
                             .Include(i => i.Restricoes)
                             .Include(i => i.Riscos)
                             .Include(i => i.Beneficios)
                             .Include(i => i.Escopos)
                             .Include(i => i.NaoEscopos)
                             .Include(i => i.Requisitos)
                             .Include(i => i.Premissas)
                             .Include(i => i.MarcosEntregas).ThenInclude(x => x.Responsavel)
                             .Include(i => i.MarcosEntregas).ThenInclude(x => x.TipoEntrega)
                             .Include(i => i.MarcosEntregas).ThenInclude(x => x.SituacaoEntrega)
                             .Include(i => i.MarcosEntregas).ThenInclude(x => x.AtividadesEntregas)
                             .Include(i => i.MarcosEntregasRelacionado).ThenInclude(x => x.MarcosEntrega)
                             .Include(i => i.MarcosEntregasRelacionado).ThenInclude(x => x.Responsavel)
                             .Include(i => i.MarcosEntregasRelacionado).ThenInclude(x => x.AtividadesEntregas)
                             .Include(i => i.Arquivos)
                             .Include(i => i.PartesInteressadas).ThenInclude(x => x.Unidade)
                             .Include(i => i.EquipeApoio).ThenInclude(x => x.UserApoio)
                             .FirstOrDefaultAsync(x => x.CO_PROJETO == projetoId);

            list.MarcosEntregas = list.MarcosEntregas.OrderBy(x => x.DT_PREVISAO).ToList();
            return list;
        }

        public async Task<IEnumerable<Projeto>> ObterTodosComIncludes()
        {
            return await Entity.Include(i => i.Objetivos)
                            .Include(i => i.Gerente)
                            .Include(i => i.Demandante)
                            .Include(i => i.StatusProjeto)
                            .Include(i => i.TipoProjeto)
                            .Include(i => i.CategoriaProjeto)
                            .Include(i => i.ProjetosFilho)
                            .Include(i => i.MarcosEntregas).ThenInclude(x => x.SituacaoEntrega).OrderBy(x => x.DT_INICIO)
                            .Include(i => i.MarcosEntregas).ThenInclude(x => x.Responsavel)
                            .Include(i => i.MarcosEntregas).ThenInclude(x => x.TipoEntrega)
                            .Include(i => i.MarcosEntregas).ThenInclude(x => x.AtividadesEntregas)
                            .Include(i => i.MarcosEntregasRelacionado).ThenInclude(x => x.MarcosEntrega)
                            .Include(i => i.MarcosEntregasRelacionado).ThenInclude(x => x.AtividadesEntregas)
                            .Include(i => i.MarcosEntregasRelacionado).ThenInclude(x => x.Responsavel)
                            .Include(i => i.PartesInteressadas).ThenInclude(x => x.Unidade)
                            .Include(i => i.EquipeApoio).ThenInclude(x => x.UserApoio)
                            .ToListAsync();
        }

        public async Task<IEnumerable<object>> ObterItensProjeto(int cO_PROJETO, TipoItemProjeto tipoItemProjeto)
        {
            switch (tipoItemProjeto)
            {
                case TipoItemProjeto.Apoio:
                    return await DbContext.Set<Apoio>()
                        .Where(x => x.CO_PROJETO == cO_PROJETO)
                        .ToListAsync();

                case TipoItemProjeto.Beneficio:
                    return await DbContext.Set<Beneficio>()
                       .Where(x => x.CO_PROJETO == cO_PROJETO)
                       .ToListAsync();

                case TipoItemProjeto.Custo:
                    return await DbContext.Set<Custo>()
                       .Where(x => x.CO_PROJETO == cO_PROJETO)
                       .ToListAsync();

                case TipoItemProjeto.Escorpo:
                    return await DbContext.Set<Escopo>()
                        .Where(x => x.CO_PROJETO == cO_PROJETO)
                        .ToListAsync();

                case TipoItemProjeto.Justificativa:
                    return await DbContext.Set<Justificativa>()
                        .Where(x => x.CO_PROJETO == cO_PROJETO)
                        .ToListAsync();

                case TipoItemProjeto.NaoEscorpo:
                    return await DbContext.Set<NaoEscopo>()
                        .Where(x => x.CO_PROJETO == cO_PROJETO)
                        .ToListAsync();

                case TipoItemProjeto.MarcosEntrega:
                    return await DbContext.Set<MarcosEntrega>()
                        .Include(x => x.SituacaoEntrega)
                        .Include(x => x.Responsavel)
                        .Include(x => x.TipoEntrega)
                        .Include(x => x.AtividadesEntregas)
                        .Where(x => x.CO_PROJETO == cO_PROJETO)
                        .ToListAsync();

                case TipoItemProjeto.MarcosEntregaRelacionado:
                    return await DbContext.Set<MarcosEntregaRelacionado>()
                        .Include(x => x.MarcosEntrega)
                        .Include(x => x.AtividadesEntregas)
                        .Include(x => x.Responsavel)
                        .Where(x => x.CO_PROJETO == cO_PROJETO)
                        .ToListAsync();

                case TipoItemProjeto.Objetivo:
                    return await DbContext.Set<Objetivo>()
                       .Where(x => x.CO_PROJETO == cO_PROJETO)
                       .ToListAsync();

                case TipoItemProjeto.ParteInteressada:
                    return await DbContext.Set<ParteInteressada>()
                        .Where(x => x.CO_PROJETO == cO_PROJETO)
                        .ToListAsync();

                case TipoItemProjeto.Premissa:
                    return await DbContext.Set<Premissa>()
                       .Where(x => x.CO_PROJETO == cO_PROJETO)
                       .ToListAsync();

                case TipoItemProjeto.Requisito:
                    return await DbContext.Set<Requisito>()
                       .Where(x => x.CO_PROJETO == cO_PROJETO)
                       .ToListAsync();

                case TipoItemProjeto.Restricao:
                    return await DbContext.Set<Restricao>()
                       .Where(x => x.CO_PROJETO == cO_PROJETO)
                       .ToListAsync();

                case TipoItemProjeto.Risco:
                    return await DbContext.Set<Risco>()
                       .Where(x => x.CO_PROJETO == cO_PROJETO)
                       .ToListAsync();
            }

            return new List<object>();
        }
    }
}