using AutoMapper;
using Solution.Aplicacao.Localizacoes.Servicos.Interfaces;
using Solution.DataTransfer.Localizacoes.Requests;
using Solution.DataTransfer.Localizacoes.Responses;
using Solution.DataTransfer.Utils;
using Solution.Dominio.Localizacoes.Entidades;
using Solution.Dominio.Localizacoes.Repositorios;
using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.Membros.Servicos.Interfaces;
using Solution.Dominio.Localizacoes.Servicos.Interfaces;
using Solution.Dominio.Quebradas.Entidades;
using Solution.Dominio.Quebradas.Servicos.Interfaces;
using Solution.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Aplicacao.Localizacoes.Servicos
{
    public class LocalizacoesAppServico : ILocalizacoesAppServicos
    {
        private readonly ILocalizacoesRepositorio localizacoesRepositorio;
        private readonly ILocalizacoesServicos localizacoesServico;
        private readonly IMembrosServico membrosServico;
        private readonly IQuebradasServicos quebradasServico;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LocalizacoesAppServico(ILocalizacoesRepositorio localizacoesRepositorio,
               ILocalizacoesServicos localizacoesServico,
               IMembrosServico membrosServico,
               IQuebradasServicos quebradasServico,
               IUnitOfWork unitOfWork,
               IMapper mapper)
        {
            this.localizacoesRepositorio = localizacoesRepositorio;
            this.localizacoesServico = localizacoesServico;
            this.membrosServico = membrosServico;
            this.quebradasServico = quebradasServico;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public LocalizacaoResponse Recuperar(long id)
        {
            Localizacao entidade = localizacoesRepositorio.Recuperar(id);
            return mapper.Map<LocalizacaoResponse>(entidade);
        }

        public PaginacaoConsulta<LocalizacaoResponse> Listar(LocalizacaoListarRequest request)
        {
            //IQueryable<Membro> query = membrosRepositorio.Query().Where(x => x.IsDeleted == false);
            IQueryable<Localizacao> query = localizacoesRepositorio.Query();

            if (request.CodigoMembro.HasValue)
                query = query.Where(x => x.Membro.Id.ToString().Contains(request.CodigoMembro.ToString()));
            if (request.CodigoQuebrada.HasValue)
                query = query.Where(x => x.Quebrada.Id.ToString().Contains(request.CodigoQuebrada.ToString()));
            return mapper.Map<PaginacaoConsulta<LocalizacaoResponse>>(query.Paginar(request));
        }

        public LocalizacaoResponse Inserir(LocalizacaoInserirRequest request)
        {
            Membro membro = membrosServico.Validar(request.CodigoMembro);
            Quebrada quebrada = quebradasServico.Validar(request.CodigoQuebrada);

            try
            {
                unitOfWork.BeginTransaction();
                Localizacao entidade = localizacoesServico.Inserir(membro, quebrada, request.DataInicio, request.DataFim);
                unitOfWork.Commit();
                return mapper.Map<LocalizacaoResponse>(entidade);

            }
            catch (System.Exception)
            {
                unitOfWork.Rollback();
                throw;
            }

        }

        public LocalizacaoResponse Editar(long id, LocalizacaoEditarRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Localizacao entidade = localizacoesServico.Editar(id, request.Membro, request.Quebrada, request.DataInicio, request.DataFim);
                unitOfWork.Commit();
                return mapper.Map<LocalizacaoResponse>(entidade);

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
                localizacoesServico.Excluir(id);
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
