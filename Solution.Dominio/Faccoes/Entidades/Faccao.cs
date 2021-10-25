using System;
using System.Collections.Generic;

using Solution.Dominio.Membros.Entidades;

namespace Solution.Dominio.Faccoes.Entidades
{
    public class Faccao
    {
        public virtual long Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Sigla { get; protected set; }
        public virtual string UFOrigem { get; protected set; }
        public virtual string AnoOrigem { get; protected set; }
        public virtual string NomeLider { get; protected set; } // poderia ser um membro
        public virtual bool IsDeleted { get; protected set; }
        public virtual DateTime? DataDesativacao { get; protected set; }
        public virtual string MotivoDesativacao { get; set; }

        public virtual IList<Membro> Membros { get; protected set; }

        protected Faccao() { }

        public Faccao(string nome, string sigla, string ufOrigem, string anoOrigem, string nomeLider, bool isDeleted, DateTime? dtDesativacao, string motivoDesativacao)
        {
            SetNome(nome);
            SetSigla(sigla);
            SetUFOrigem(ufOrigem);
            SetAnoOrigem(anoOrigem);
            SetNomeLider(nomeLider);
            SetIsDeleted(isDeleted);
            SetMotivoDesativacao(motivoDesativacao, dtDesativacao);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Nome da Faccao é obrigatorio");
            if (nome.Length > 200)
                throw new Exception("Nome da Faccao não pode possuir mais de 200 caracteres");
            Nome = nome;
        }

        public virtual void SetSigla(string sigla)
        {
            if (string.IsNullOrWhiteSpace(sigla))
                throw new Exception("Sigla da Faccao é obrigatorio");
            if (sigla.Length > 50)
                throw new Exception("Sigla da Faccao não pode possuir mais de 50 caracteres");
            Sigla = sigla;
        }

        public virtual void SetUFOrigem(string ufOrigem)
        {
            if (string.IsNullOrWhiteSpace(ufOrigem))
                throw new Exception("UF de origem é obrigatorio");
            if (ufOrigem.Length > 2)
                throw new Exception("UF de origem não pode possuir mais de 50 caracteres");
            UFOrigem = ufOrigem;
        }

        public virtual void SetAnoOrigem(string anoOrigem)
        {
            if (string.IsNullOrWhiteSpace(anoOrigem))
                throw new Exception("Ano de origem é obrigatorio");
            if (anoOrigem.Length > 4)
                throw new Exception("Ano de origem não pode possuir mais de 4 caracteres");
            AnoOrigem = anoOrigem;
        }

        public virtual void SetNomeLider(string nomeLider)
        {
            if (string.IsNullOrWhiteSpace(nomeLider))
                throw new Exception("Nome do Lider é obrigatorio");
            if (nomeLider.Length > 100)
                throw new Exception("Nome do Lider não pode possuir mais de 100 caracteres");
            NomeLider = nomeLider;
        }

        public virtual void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }

        public virtual void SetMotivoDesativacao(string motivoDesativacao, DateTime? dt)
        {
            if (IsDeleted == true && string.IsNullOrEmpty(motivoDesativacao))
                throw new Exception("Motivo da desativação é obrigatório.");
            if (IsDeleted == false && !string.IsNullOrEmpty(motivoDesativacao))
                throw new Exception("Não é possível incluir motivo de desativação");
            MotivoDesativacao = motivoDesativacao;
            DataDesativacao = dt;
        }


    }
}
