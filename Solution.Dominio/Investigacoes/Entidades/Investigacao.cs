using System;

using Solution.Dominio.Membros.Entidades;

namespace Solution.Dominio.Investigacoes.Entidades
{
    public class Investigacao
    {
        public virtual long Id { get; protected set; }
        public virtual Membro Membro { get; protected set; }
        public virtual string TituloOperacao { get; protected set; }
        public virtual string PromotoriaVara { get; protected set; }
        public virtual string Estado { get; protected set; }
        public virtual string Prova { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual DateTime DataInvestigacao { get; protected set; }

        protected Investigacao() { }
        public Investigacao(Membro membro, string tituloOperacao, string promotoriaVara, string estado, string prova, string descricao, DateTime? dataInvestigacao)
        {
            SetMembro(membro);
            SetTituloOperacao(tituloOperacao);
            SetPromotoriaVara(promotoriaVara);
            SetEstado(estado);
            SetProva(prova);
            SetDescricao(descricao);
            SetDataInvestigacao(dataInvestigacao);
        }

        private void SetMembro(Membro membro)
        {
            Membro = membro ?? throw new Exception("Membro é obrigatorio para investigação");
        }
        public virtual void SetTituloOperacao(string tituloOperacao)
        {
            if (string.IsNullOrWhiteSpace(tituloOperacao))
                throw new Exception("Titulo da operação é obrigatoria");
            if (tituloOperacao.Length > 200)
                throw new Exception("Titulo de operação não pode possuir mais de 200 caracteres");
            TituloOperacao = tituloOperacao;
        }
        public virtual void SetPromotoriaVara(string promotoriaVara)
        {
            if (string.IsNullOrWhiteSpace(promotoriaVara))
                throw new Exception("Vara de promotoria é obrigatoria");
            PromotoriaVara = promotoriaVara;
        }
        public virtual void SetEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
                throw new Exception("Vara de promotoria é obrigatoria");
            Estado = estado;
        }
        public virtual void SetProva(string prova)
        {
            Prova = prova;
        }
        public virtual void SetDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new Exception("Descricao é obrigatoria");
            if (50 < descricao.Length)
                throw new Exception("Descricao tem que possuir mais que 50 caracteres");
            Descricao = descricao;
        }
        private void SetDataInvestigacao(DateTime? dataInvestigacao)
        {
            if (dataInvestigacao is null)
                throw new Exception("Data de investigação é obrigatoria");
            DataInvestigacao = dataInvestigacao.Value;
        }
    }
}
