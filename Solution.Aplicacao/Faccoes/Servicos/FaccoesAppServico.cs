using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using Solution.Aplicacao.Faccoes.Servicos.Interfaces;
using Solution.DataTransfer.Faccoes.Requests;
using Solution.DataTransfer.Faccoes.Responses;
using Solution.DataTransfer.Utils;
using Solution.Dominio.Faccoes.Entidades;
using Solution.Dominio.Faccoes.Repositorios;
using Solution.Dominio.Faccoes.Services.Interfaces;
using Solution.Dominio.Utils;

namespace Solution.Aplicacao.Faccoes.Servicos
{
    public class FaccoesAppServico : IFaccoesAppServicos
    {
        //private readonly IFaccoesRepositorio faccoesRepositorio;
        //private readonly IMapper mapper;

        private readonly IFaccoesRepositorio faccoesRepositorio;
        private readonly IFaccoesServicos faccoesServico;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FaccoesAppServico(IFaccoesRepositorio faccoesRepositorio,
                               IFaccoesServicos faccoesServico,
                               IUnitOfWork unitOfWork,
                               IMapper mapper)
        {
            this.faccoesRepositorio = faccoesRepositorio;
            this.faccoesServico = faccoesServico;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public FaccaoResponse Recuperar(long id)
        {
            Faccao entidade = faccoesRepositorio.Recuperar(id);
            return mapper.Map<FaccaoResponse>(entidade);
        }

        public PaginacaoConsulta<FaccaoResponse> Listar(FaccaoListarRequest request)
        {
            IQueryable<Faccao> query = faccoesRepositorio.Query().Where(x => x.IsDeleted == false);

            if (!string.IsNullOrWhiteSpace(request.Nome))
                query = query.Where(x => x.Nome.ToUpper().Contains(request.Nome.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.Sigla))
                query = query.Where(x => x.Sigla.ToUpper().Contains(request.Sigla.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.UFOrigem))
                query = query.Where(x => x.UFOrigem.ToUpper().Contains(request.UFOrigem.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.NomeLider))
                query = query.Where(x => x.NomeLider.ToUpper().Contains(request.NomeLider.ToUpper().Trim()));
            return mapper.Map<PaginacaoConsulta<FaccaoResponse>>(query.Paginar(request));
        }

        public FaccaoResponse Inserir(FaccaoInserirRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Faccao entidade = faccoesServico.Inserir(request.Nome, request.Sigla, request.UFOrigem, request.AnoOrigem, request.NomeLider, false);
                unitOfWork.Commit();
                return mapper.Map<FaccaoResponse>(entidade);

            }
            catch (System.Exception)
            {
                unitOfWork.Rollback();
                throw;
            }

        }

        public FaccaoResponse Editar(long id, FaccaoEditarRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Faccao entidade = faccoesServico.Editar(id, request.Nome, request.Sigla, request.UFOrigem, request.AnoOrigem, request.NomeLider, request.IsDeleted, request.DataDesativacao, request.MotivoDesativacao);
                unitOfWork.Commit();
                return mapper.Map<FaccaoResponse>(entidade);

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
                faccoesServico.Excluir(id);
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
