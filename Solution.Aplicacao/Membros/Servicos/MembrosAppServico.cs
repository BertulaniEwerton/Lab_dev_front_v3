using AutoMapper;
using Solution.Aplicacao.Membros.Interfaces;
using Solution.DataTransfer.Membros.Requests;
using Solution.DataTransfer.Membros.Responses;
using Solution.DataTransfer.Utils;
using Solution.Dominio.Faccoes.Entidades;
using Solution.Dominio.Faccoes.Services.Interfaces;
using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.Membros.Repositorios;
using Solution.Dominio.Membros.Servicos.Interfaces;
using Solution.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Solution.Aplicacao.Membros.Servicos
{
    public class MembrosAppServico : IMembrosAppServicos
    {
        private readonly IMembrosRepositorio membrosRepositorio;
        private readonly IMembrosServico membrosServico;
        private readonly IFaccoesServicos faccoesServico;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MembrosAppServico(IMembrosRepositorio membrosRepositorio,
                       IMembrosServico membrosServico,
                       IFaccoesServicos faccoesServico,
                       IUnitOfWork unitOfWork,
                       IMapper mapper)
        {
            this.membrosRepositorio = membrosRepositorio;
            this.membrosServico = membrosServico;
            this.faccoesServico = faccoesServico;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public MembroResponse Recuperar(long id)
        {
            Membro entidade = membrosRepositorio.Recuperar(id);
            return mapper.Map<MembroResponse>(entidade);
        }

        public PaginacaoConsulta<MembroResponse> Listar(MembroListarRequest request)
        {
            //IQueryable<Membro> query = membrosRepositorio.Query().Where(x => x.IsDeleted == false);
            IQueryable<Membro> query = membrosRepositorio.Query();

            if (!string.IsNullOrWhiteSpace(request.Nome))
                query = query.Where(x => x.Nome.ToUpper().Contains(request.Nome.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.NomeVulgo))
                query = query.Where(x => x.NomeVulgo.ToUpper().Contains(request.NomeVulgo.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.Matricula))
                query = query.Where(x => x.Matricula.ToUpper().Contains(request.Matricula.ToUpper().Trim()));
            if (!string.IsNullOrWhiteSpace(request.NomeMae))
                query = query.Where(x => x.NomeMae.ToUpper().Contains(request.NomeMae.ToUpper().Trim()));
            if (request.CodigoFaccao.HasValue)
                query = query.Where(x => x.Faccao.Id.ToString().Contains(request.CodigoFaccao.ToString()));
            return mapper.Map<PaginacaoConsulta<MembroResponse>>(query.Paginar(request));
        }

        public MembroResponse Inserir(MembroInserirRequest request)
        {
            Faccao faccao = faccoesServico.Validar(request.CodigoFaccao);

            try
            {
                string curDir = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());

                var index = request.Foto.IndexOf(',');
                var base64stringWithoutSignature = request.Foto.Substring(index + 1);

                index = request.Foto.IndexOf(';');
                var base64signatue = request.Foto.Substring(0, index);
                index = base64signatue.IndexOf("/");
                var extension = base64signatue.Substring(index + 1);

                byte[] bytes = Convert.FromBase64String(base64stringWithoutSignature);

                string pastaImagens = "\\Image\\";

                if (!Directory.Exists(curDir + pastaImagens))
                {
                    Directory.CreateDirectory(curDir + pastaImagens);
                }

                File.WriteAllBytes(curDir + pastaImagens + request.Nome + "." + extension, bytes);

                MemoryStream teste = new MemoryStream();

                string caminhoImagem = curDir + pastaImagens + request.Nome + "." + extension;

                request.Foto = caminhoImagem;

                unitOfWork.BeginTransaction();
                Membro entidade = membrosServico.Inserir(request.Nome, request.NomeVulgo, request.Idade, faccao, request.DataBatismo, request.DataCadastro, request.Referencia, request.Matricula, caminhoImagem, request.CPF, request.NomeMae, request.Obito, request.DataObito, request.LocalObito, request.Caracteristicas, false);
                unitOfWork.Commit();
                return mapper.Map<MembroResponse>(entidade);

            }
            catch (System.Exception)
            {
                unitOfWork.Rollback();
                throw;
            }

        }

        public MembroResponse Editar(long id, MembroEditarRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Membro entidade = membrosServico.Editar(id, request.Nome, request.NomeVulgo, request.Idade, request.Faccao, request.DataBatismo, request.DataCadastro, request.Referencia, request.Matricula, request.Foto, request.CPF, request.NomeMae, request.Obito, request.DataObito, request.LocalObito, request.Caracteristicas, request.IsDeleted, request.DataDesativacao, request.MotivoDesativacao);
                unitOfWork.Commit();
                return mapper.Map<MembroResponse>(entidade);

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
                membrosServico.Excluir(id);
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
