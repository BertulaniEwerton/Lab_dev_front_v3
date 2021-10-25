using Solution.Dominio.Faccoes.Entidades;
using Solution.Dominio.Faccoes.Repositorios;
using Solution.Dominio.Faccoes.Services.Interfaces;
using System;

namespace Solution.Dominio.Faccoes.Services
{
    public class FaccoesServicos : IFaccoesServicos
    {
        private readonly IFaccoesRepositorio faccaoRepositorio;

        public FaccoesServicos(IFaccoesRepositorio faccaoRepositorio)
        {
            this.faccaoRepositorio = faccaoRepositorio;
        }

        public Faccao Validar(long? codigo)
        {
            if (codigo is null)
                throw new Exception("Codigo de faccao invalido");
            Faccao entidade = faccaoRepositorio.Recuperar(codigo.Value);
            if (entidade is null)
                throw new Exception("Faccao não encontrada");
            return entidade;
        }

        public Faccao Inserir(string nome, string sigla, string ufOrigem, string anoOrigem, string nomeLider, bool isDeleted = false)
        {
            Faccao entidade = new(nome, sigla, ufOrigem, anoOrigem, nomeLider, isDeleted, null, string.Empty);
            return faccaoRepositorio.Inserir(entidade);
        }

        public Faccao Editar(long? codigo, string nome, string sigla, string ufOrigem, string anoOrigem, string nomeLider, bool isDeleted, DateTime? dataDesativacao, string motivoDesativacao)
        {
            Faccao entidade = Validar(codigo);

            if (nome is not null && nome != entidade.Nome)
            {
                entidade.SetNome(nome);
            }
            if (sigla is not null && sigla != entidade.Sigla)
            {
                entidade.SetSigla(sigla);
            }
            if (ufOrigem is not null && ufOrigem != entidade.UFOrigem)
            {
                entidade.SetUFOrigem(ufOrigem);
            }
            if (anoOrigem is not null && anoOrigem != entidade.AnoOrigem)
            {
                entidade.SetAnoOrigem(anoOrigem);
            }
            if (nomeLider is not null && nomeLider != entidade.NomeLider)
            {
                entidade.SetNomeLider(nomeLider);
            }
            if (isDeleted == true || isDeleted == false)
            {
                entidade.SetIsDeleted(isDeleted);

                if (isDeleted == true)
                {
                    entidade.SetMotivoDesativacao(motivoDesativacao, DateTime.Now);
                }

            }

            return faccaoRepositorio.Editar(entidade);
        }

        public void Excluir(long codigo)
        {
            Faccao entidade = Validar(codigo);
            faccaoRepositorio.Excluir(entidade);
        }

    }
}
