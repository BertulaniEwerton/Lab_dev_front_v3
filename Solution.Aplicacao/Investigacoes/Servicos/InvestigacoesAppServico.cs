using System.Linq;

using AutoMapper;

using Solution.Aplicacao.Investigacoes.Servicos.Interfaces;
using Solution.DataTransfer.Investigacoes.Requests;
using Solution.DataTransfer.Investigacoes.Responses;
using Solution.DataTransfer.Utils;
using Solution.Dominio.Investigacoes.Entidades;
using Solution.Dominio.Investigacoes.Repositorios;
using Solution.Dominio.Investigacoes.Servicos.Interfaces;
using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.Membros.Servicos.Interfaces;
using Solution.Dominio.Utils;

namespace Solution.Aplicacao.Investigacoes.Servicos
{
    public class InvestigacoesAppServico : IInvestigacoesAppServico
    {
        private readonly IInvestigacoesRepositorio investigacoesRepositorio;
        private readonly IInvestigacoesServico investigacoesServico;
        private readonly IMembrosServico membrosServico;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public InvestigacoesAppServico(IInvestigacoesRepositorio investigacoesRepositorio,
                                       IInvestigacoesServico investigacoesServico,
                                       IMembrosServico membrosServico,
                                       IUnitOfWork unitOfWork,
                                       IMapper mapper)
        {
            this.investigacoesRepositorio = investigacoesRepositorio;
            this.investigacoesServico = investigacoesServico;
            this.membrosServico = membrosServico;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public InvestigaoResponse Recuperar(long id)
        {
            Investigacao entidade = investigacoesRepositorio.Recuperar(id);
            return mapper.Map<InvestigaoResponse>(entidade);
        }
        public PaginacaoConsulta<InvestigaoResponse> Listar(InvestigacaoListarRequest request)
        {
            IQueryable<Investigacao> query = investigacoesRepositorio.Query();

            if (!string.IsNullOrWhiteSpace(request.PromotoriaVara))
                query = query.Where(x => x.PromotoriaVara.ToUpper().Contains(request.PromotoriaVara.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.Prova))
                query = query.Where(x => x.Prova.ToUpper().Contains(request.Prova.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.TituloOperacao))
                query = query.Where(x => x.TituloOperacao.ToUpper().Contains(request.TituloOperacao.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.Estado))
                query = query.Where(x => x.Estado.ToUpper().Contains(request.Estado.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.Descricao))
                query = query.Where(x => x.Descricao.ToUpper().Contains(request.Descricao.ToUpper().Trim()));
            if (request.DataFim.HasValue && request.DataInicio.HasValue)
                query = query.Where(x => x.DataInvestigacao.Date > request.DataInicio.Value.Date && x.DataInvestigacao.Date < request.DataFim.Value.Date);
            if (request.CodigoMembro.HasValue)
                query = query.Where(x => x.Membro.Id.ToString().Contains(request.CodigoMembro.ToString()));
            return mapper.Map<PaginacaoConsulta<InvestigaoResponse>>(query.Paginar(request));
        }
        public InvestigaoResponse Inserir(InvestigacaoInserirRequest request)
        {
            Membro membro = membrosServico.Validar(request.CodigoMembro);
            try
            {
                unitOfWork.BeginTransaction();
                Investigacao entidade = investigacoesServico.Inserir(membro, request.TituloOperacao, request.PromotoriaVara, request.Estado, request.Prova, request.Descricao, request.DataInvestigacao);
                unitOfWork.Commit();
                return mapper.Map<InvestigaoResponse>(entidade);

            }
            catch (System.Exception)
            {
                unitOfWork.Rollback();
                throw;
            }

        }
        public InvestigaoResponse Editar(long id, InvestigacaoEditarRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Investigacao entidade = investigacoesServico.Editar(id, request.TituloOperacao, request.PromotoriaVara, request.Prova, request.Descricao);
                unitOfWork.Commit();
                return mapper.Map<InvestigaoResponse>(entidade);

            }
            catch (System.Exception)
            {
                unitOfWork.Rollback();
                throw;
            }

        }
        public void Deletar(long id)
        {
            try
            {
                unitOfWork.BeginTransaction();
                investigacoesServico.Excluir(id);
                unitOfWork.Commit();
            }
            catch (System.Exception)
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
