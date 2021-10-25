using System;

using Solution.Dominio.Investigacoes.Entidades;
using Solution.Dominio.Investigacoes.Repositorios;
using Solution.Dominio.Investigacoes.Servicos.Interfaces;
using Solution.Dominio.Membros.Entidades;

namespace Solution.Dominio.Investigacoes.Servicos
{
    public class InvestigacoesServico : IInvestigacoesServico
    {
        private readonly IInvestigacoesRepositorio investigacoesRepositorio;

        public InvestigacoesServico(IInvestigacoesRepositorio investigacoesRepositorio)
        {
            this.investigacoesRepositorio = investigacoesRepositorio;
        }
        public Investigacao Validar(long? codigo)
        {
            if (codigo is null)
                throw new Exception("Codigo da investigação invalida");
            Investigacao entidade = investigacoesRepositorio.Recuperar(codigo.Value);
            if (entidade is null)
                throw new Exception("Investigação não encontrada");
            return entidade;
        }
        public Investigacao Inserir(Membro membro, string tituloOperacao, string promotoriaVara, string estado, string prova, string descricao, DateTime? dataInvestigacao)
        {
            Investigacao entidade = new(membro, tituloOperacao, promotoriaVara, estado, prova, descricao,dataInvestigacao);
            return investigacoesRepositorio.Inserir(entidade);
        }
        public Investigacao Editar(long? codigo, string tituloOperacao, string promotoriaVara, string prova, string descricao)
        {
            Investigacao entidade = Validar(codigo);

            if(tituloOperacao is not null && tituloOperacao != entidade.TituloOperacao)
            {
                entidade.SetTituloOperacao(tituloOperacao);
            }
            if(promotoriaVara is not null && promotoriaVara != entidade.PromotoriaVara)
            {
                entidade.SetPromotoriaVara(promotoriaVara);
            }
            if (prova is not null && prova != entidade.Prova)
            {
                prova = $"{entidade.Prova}\n{prova}";
                entidade.SetProva(prova);
            }
            if (descricao is not null && descricao != entidade.Descricao)
            {
                entidade.SetDescricao(descricao);
            }
            return investigacoesRepositorio.Editar(entidade);
        }
        public void Excluir(long codigo)
        {
            Investigacao entidade = Validar(codigo);
            investigacoesRepositorio.Excluir(entidade);
        }
    }
}
