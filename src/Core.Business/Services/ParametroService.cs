using AutoMapper;
using Core.Business.Entities.Projetos;
using Core.Business.Interfaces;
using Core.Business.Interfaces.Repositories;
using Core.Business.Interfaces.Services;
using Core.Business.ViewModels;
using Core.Business.ViewModels.Projetos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Services
{
    public class ParametroService : BaseService , IParametroService
    {
        private readonly IMapper _mapper;
        private readonly IComplexidadeRepository _complexidade;
        private readonly IPrioridadeRepository _prioridade;
        private readonly IStatusProjetoRepository _status;
        private readonly ITipoProjetoRepository _tipo;
        private readonly ICategoriaRepository _categoria;
        private readonly ITipoMarcosEntregasRepository _tipoMarcosEntrega;
        private readonly IStatusAtividadeMarcoEntregaRepository _statusAtividadeMarcoEntrega;
        public ParametroService(INotificador notificador,
                                IUser user,
                                IMapper mapper,
                                IComplexidadeRepository complexidade,
                                IPrioridadeRepository prioridade,
                                IStatusProjetoRepository status,
                                ICategoriaRepository categoria,
                                ITipoMarcosEntregasRepository tipoMarcosEntrega,
                                IStatusAtividadeMarcoEntregaRepository statusAtividadeMarcoEntrega,
        ITipoProjetoRepository tipo) : base(notificador, user)
        {
            _mapper = mapper;
            _complexidade = complexidade;
            _prioridade = prioridade;
            _tipo = tipo;
            _status = status;
            _categoria = categoria;
            _tipoMarcosEntrega = tipoMarcosEntrega;
            _statusAtividadeMarcoEntrega = statusAtividadeMarcoEntrega;

        }

        public async Task<ParametrosViewModel> ObterParametros()
        {
            ParametrosViewModel parametros = new ParametrosViewModel();

            parametros.Complexidades = _mapper.Map<IEnumerable<ComplexidadeProjetoViewModel>>(await _complexidade.GetAllAsync());
            parametros.Prioridades = _mapper.Map<IEnumerable<PrioridadeProjetoViewModel>>(await _prioridade.GetAllAsync());
            parametros.Status = _mapper.Map<IEnumerable<StatusProjetoViewModel>>(await _status.GetAllAsync());
            parametros.TiposProjeto = _mapper.Map<IEnumerable<TipoProjetoViewModel>>(await _tipo.GetAllAsync());
            parametros.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoria.GetAllAsync());
            parametros.TiposEntregas = _mapper.Map<IEnumerable<TipoMarcosEntregasViewModels>>(await _tipoMarcosEntrega.GetAllAsync());
            parametros.StatusAtividadesEntrega = _mapper.Map<IEnumerable<StatusAtividadeMarcoEntregaViewModel>>(await _statusAtividadeMarcoEntrega.GetAllAsync());

            return parametros;
        }

        /*Complexidade*/
        public async Task AdicionarComplexidade(ComplexidadeProjetoViewModel model) {

            await _complexidade.CreateAsync(_mapper.Map<ComplexidadeProjeto>(model));

        }
        public async Task AtualizarComplexidade(ComplexidadeProjetoViewModel model)
        {
            await _complexidade.UpdateAsync(_mapper.Map<ComplexidadeProjeto>(model));
        }

        /*Categoria*/
        public async Task AdicionarCategoria(CategoriaViewModel model)
        {
            await _categoria.CreateAsync(_mapper.Map<Categoria>(model));
        }

        public async Task AtualizarCategoria(CategoriaViewModel model)
        {
            await _categoria.UpdateAsync(_mapper.Map<Categoria>(model));
        }


        /*Prioridade*/
        public async Task AdicionaPrioridade(PrioridadeProjetoViewModel model)
        {
            await _prioridade.CreateAsync(_mapper.Map<PrioridadeProjeto>(model));
        }

        public async Task AtualizarPrioridade(PrioridadeProjetoViewModel model)
        {
            await _prioridade.UpdateAsync(_mapper.Map<PrioridadeProjeto>(model));
        }

        /*Tipo de Projeto*/
        public async Task AdicionarTipoProjeto(TipoProjetoViewModel model)
        {
            await _tipo.CreateAsync(_mapper.Map<TipoProjeto>(model));
        }

        public async Task AtualizarTipoProjeto(TipoProjetoViewModel model)
        {
            await _tipo.UpdateAsync(_mapper.Map<TipoProjeto>(model));
        }

        /*Status de Projeto*/
        public async Task AdcionarStatusProjeto(StatusProjetoViewModel model)
        {
            await _status.CreateAsync(_mapper.Map<StatusProjeto>(model));
        }



        public async Task AtualizarStatusProjeto(StatusProjetoViewModel model)
        {
            await _status.UpdateAsync(_mapper.Map<StatusProjeto>(model));
        }

        public async Task<bool> ComplexidadeExiste(int Complexidade)
        {
            return await _complexidade.ExistsAsync(x => x.COMPLEXIDADE == Complexidade);
        }

        public async Task<bool> PrioridadeExiste(int Prioridade)
        {
            return await _prioridade.ExistsAsync(x => x.PRIORIDADE == Prioridade);
        }

        public async Task<bool> TipoProjetoExiste(string TipoProjeto)
        {
            return await _tipo.ExistsAsync(x => x.DESCRICAO == TipoProjeto);
        }

        public async Task<bool> StatusProjetoExiste(string statusProjeto)
        {
            return await _status.ExistsAsync(x => x.DESCRICAO == statusProjeto);
        }



        public async Task<bool> CategoriaProjetoExiste(string categoria)
        {
            return await _categoria.ExistsAsync(x => x.DESCRICAO == categoria);
        }

        public async Task AdicionarTipoMarcosEntregas(TipoMarcosEntregasViewModels model)
        {
            await _tipoMarcosEntrega.CreateAsync(_mapper.Map<TipoMarcosEntregas>(model));
        }

        public async Task AtualizarTipoMarcosEntregas(TipoMarcosEntregasViewModels model)
        {
            await _tipoMarcosEntrega.UpdateAsync(_mapper.Map<TipoMarcosEntregas>(model));
        }

        public async Task<bool> TipoMarcosEntregasExiste(string TipoProjeto)
        {
            return await _tipoMarcosEntrega.ExistsAsync(x => x.NOME == TipoProjeto); 
        }

        public async Task<IEnumerable<TipoMarcosEntregasViewModels>> ObterTipoMarcosEntregas()
        {
            return _mapper.Map<IEnumerable<TipoMarcosEntregasViewModels>>(await _tipoMarcosEntrega.GetAllAsync());
        }

        public async Task AdicionarStatusAtividadeEntrega(StatusAtividadeMarcoEntregaViewModel model)
        {
            await _statusAtividadeMarcoEntrega.CreateAsync(_mapper.Map<StatusAtividadeMarcoEntrega>(model));
        }

        public async Task AtualizarStatusAtividadeEntrega(StatusAtividadeMarcoEntregaViewModel model)
        {
            await _statusAtividadeMarcoEntrega.UpdateAsync(_mapper.Map<StatusAtividadeMarcoEntrega>(model));
        }

        public async Task<bool> StatusAtividadeEntregaExiste(string statusAtividade)
        {
            return await _statusAtividadeMarcoEntrega.ExistsAsync(x => x.DESCRICAO == statusAtividade);
        }

        public async Task<IEnumerable<StatusAtividadeMarcoEntregaViewModel>> ObterStatusAtvidadeMarcosEntrega()
        {
            return _mapper.Map<IEnumerable<StatusAtividadeMarcoEntregaViewModel>>(await _statusAtividadeMarcoEntrega.GetAllAsync());
        }
    }
}
