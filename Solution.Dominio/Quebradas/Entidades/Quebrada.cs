using System;
using System.Collections.Generic;

using Solution.Dominio.Localizacoes.Entidades;

namespace Solution.Dominio.Quebradas.Entidades
{
    public class Quebrada
    {
        public virtual long Id { get; protected set; }
        public virtual string Telefone { get; protected set; }
        public virtual string Endereco { get; protected set; }
        public virtual string Bairro { get; protected set; }
        public virtual string Cidade { get; protected set; }
        public virtual string Uf { get; protected set; }
        public virtual string Origem { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual DateTime? DataDesativacao { get; protected set; }
        public virtual string MotivoDesativacao { get; set; }

        public virtual IList<Localizacao> Localizacoes { get; protected set; }

        protected Quebrada() { }

        public Quebrada(string telefone, string endereco, string bairro, string cidade, string uf, string origem,  bool isDeleted, DateTime? dtDesativacao, string motivoDesativacao)
        {
            SetTelefone(telefone);
            SetEndereco(endereco);
            SetBairro(bairro);
            SetCidade(cidade);
            SetUF(uf);
            SetOrigem(origem);
            SetIsDeleted(isDeleted);
            SetMotivoDesativacao(motivoDesativacao, dtDesativacao);
        }

        public virtual void SetTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                throw new Exception("Telefone é obrigatorio");
            if (telefone.Length > 20)
                throw new Exception("Telefone não pode possuir mais de 20 caracteres");
            Telefone = telefone;
        }

        public virtual void SetEndereco(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new Exception("Endereco é obrigatorio");
            if (endereco.Length > 200)
                throw new Exception("Endereco não pode possuir mais de 200 caracteres");
            Endereco = endereco;
        }

        public virtual void SetBairro(string bairro)
        {
            if (string.IsNullOrWhiteSpace(bairro))
                throw new Exception("Bairro é obrigatorio");
            if (bairro.Length > 100)
                throw new Exception("Bairro não pode possuir mais de 100 caracteres");
            Bairro = bairro;
        }

        public virtual void SetCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade))
                throw new Exception("Cidade é obrigatorio");
            if (cidade.Length > 50)
                throw new Exception("Cidade não pode possuir mais de 100 caracteres");
            Cidade = cidade;
        }

        public virtual void SetUF(string uf)
        {
            if (string.IsNullOrWhiteSpace(uf))
                throw new Exception("UF é obrigatorio");
            if (uf.Length > 2)
                throw new Exception("UF não pode possuir mais de 2 caracteres");
            Uf = uf;
        }

        public virtual void SetOrigem(string origem)
        {
            if (string.IsNullOrWhiteSpace(origem))
                throw new Exception("Origem é obrigatorio");
            if (origem.Length > 200)
                throw new Exception("Origem não pode possuir mais de 200 caracteres");
            Origem = origem;
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
