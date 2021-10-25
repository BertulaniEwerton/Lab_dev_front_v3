using AutoMapper;
using Solution.Aplicacao.Quebradas.Servicos.Interfaces;
using Solution.DataTransfer.Quebradas.Requests;
using Solution.DataTransfer.Quebradas.Responses;
using Solution.DataTransfer.Utils;
using Solution.Dominio.Quebradas.Entidades;
using Solution.Dominio.Quebradas.Repositorios;
using Solution.Dominio.Quebradas.Servicos.Interfaces;
using Solution.Dominio.Utils;
using System.Linq;

namespace Solution.Aplicacao.Quebradas.Servicos
{
    public class QuebradasAppServico : IQuebradasAppServicos
    {
        private readonly IQuebradasRepositorio quebradaRepositorio;
        private readonly IQuebradasServicos quebradaServico;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public QuebradasAppServico(IQuebradasRepositorio quebradaRepositorio,
                       IQuebradasServicos quebradaServico,
                       IUnitOfWork unitOfWork,
                       IMapper mapper)
        {
            this.quebradaRepositorio = quebradaRepositorio;
            this.quebradaServico = quebradaServico;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public QuebradaResponse Recuperar(long id)
        {
            Quebrada entidade = quebradaRepositorio.Recuperar(id);
            return mapper.Map<QuebradaResponse>(entidade);
        }

        public PaginacaoConsulta<QuebradaResponse> Listar(QuebradaListarRequest request)
        {
            IQueryable<Quebrada> query = quebradaRepositorio.Query().Where(x => x.IsDeleted == false);

            if (!string.IsNullOrWhiteSpace(request.Telefone))
                query = query.Where(x => x.Telefone.ToUpper().Contains(request.Telefone.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.Endereco))
                query = query.Where(x => x.Endereco.ToUpper().Contains(request.Endereco.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.Bairro))
                query = query.Where(x => x.Bairro.ToUpper().Contains(request.Bairro.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.Cidade))
                query = query.Where(x => x.Cidade.ToUpper().Contains(request.Cidade.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.Uf))
                query = query.Where(x => x.Cidade.ToUpper().Contains(request.Cidade.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.Origem))
                query = query.Where(x => x.Origem.ToUpper().Contains(request.Origem.ToUpper().Trim()));

            return mapper.Map<PaginacaoConsulta<QuebradaResponse>>(query.Paginar(request));
        }

        public QuebradaResponse Inserir(QuebradaInserirRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Quebrada entidade = quebradaServico.Inserir(request.Telefone, request.Endereco, request.Bairro, request.Cidade, request.Uf, request.Origem, false);
                unitOfWork.Commit();
                return mapper.Map<QuebradaResponse>(entidade);

            }
            catch (System.Exception)
            {
                unitOfWork.Rollback();
                throw;
            }

        }

        public QuebradaResponse Editar(long id, QuebradaEditarRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Quebrada entidade = quebradaServico.Editar(id, request.Telefone, request.Endereco, request.Bairro, request.Cidade, request.Uf, request.Origem, request.IsDeleted, request.DataDesativacao, request.MotivoDesativacao);
                unitOfWork.Commit();
                return mapper.Map<QuebradaResponse>(entidade);

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
                quebradaServico.Excluir(id);
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
