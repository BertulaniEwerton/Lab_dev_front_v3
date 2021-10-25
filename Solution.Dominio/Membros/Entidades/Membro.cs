using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using Solution.Dominio.Dossies.Entidades;
using Solution.Dominio.Faccoes.Entidades;
using Solution.Dominio.Investigacoes.Entidades;
using Solution.Dominio.Localizacoes.Entidades;
using Solution.Dominio.Padrinhos.Entidades;
using Solution.Dominio.Processos.Entidades;

namespace Solution.Dominio.Membros.Entidades
{
    public class Membro
    {
        public virtual long Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string NomeVulgo { get; protected set; }
        public virtual int Idade { get; protected set; }

        [JsonIgnore]
        public virtual Faccao Faccao { get; protected set; }
        public virtual DateTime DataBatismo { get; protected set; }
        public virtual DateTime DataCadastro { get; protected set; }
        public virtual string Referencia { get; protected set; }
        public virtual string Matricula { get; protected set; }
        public virtual string Foto { get; protected set; }
        public virtual string CPF { get; protected set; }
        public virtual string NomeMae { get; protected set; }
        public virtual bool Obito { get; protected set; } // validar se é necessario
        public virtual DateTime DataObito { get; protected set; }
        public virtual string LocalObito { get; protected set; }
        public virtual string Caracteristicas { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual DateTime? DataDesativacao { get; protected set; }
        public virtual string MotivoDesativacao { get; protected set; }


        public virtual IList<Padrinho> Padrinhos { get; protected set; }
        public virtual IList<Dossie> Dossies { get; protected set; }
        public virtual IList<Localizacao> Localizacoes { get; protected set; }
        public virtual IList<Investigacao> Investigacoes { get; protected set; }
        public virtual IList<Processo> Processos { get; protected set; }

        protected Membro() { }

        public Membro(string nome, string nomeVulgo, int idade, Faccao faccao, DateTime dataBatismo, DateTime dataCadastro, string referencia, string matricula, string foto, string cpf, string nomeMae, bool obito, DateTime dataObito, string localObito, string caracteristicas, bool isDeleted, DateTime? dtDesativacao, string motivoDesativacao)
        {
            SetNome(nome);
            SetNomeVulgo(nomeVulgo);
            SetIdade(idade);
            SetFaccao(faccao);
            SetDataBatismo(dataBatismo);
            SetDataCadastro(dataCadastro);
            SetReferencia(referencia);
            SetMatricula(matricula);
            SetFoto(foto);
            SetCpf(cpf);
            SetNomeMae(nomeMae);
            SetObito(obito);
            SetDataObito(dataObito);
            SetLocalObito(localObito);
            SetCaracteristicas(caracteristicas);
            SetIsDeleted(isDeleted);
            SetMotivoDesativacao(motivoDesativacao, dtDesativacao);

        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Nome do Membro é obrigatorio");
            if (nome.Length > 100)
                throw new Exception("Nome do Membro não pode possuir mais de 100 caracteres");
            Nome = nome;
        }

        public virtual void SetNomeVulgo(string nomeVulgo)
        {
            if (string.IsNullOrWhiteSpace(nomeVulgo))
                throw new Exception("Vulgo do Membro é obrigatorio");
            if (nomeVulgo.Length > 100)
                throw new Exception("Vulgo do Membro não pode possuir mais de 100 caracteres");
            NomeVulgo = nomeVulgo;
        }

        public virtual void SetIdade(int idade)
        {
            if (string.IsNullOrWhiteSpace(idade.ToString()))
                throw new Exception("Idade do Membro é obrigatorio");
            if (Idade.ToString().Length > 3)
                throw new Exception("Idade do Membro não pode possuir mais de 3 caracteres");
            Idade = idade;
        }

        public virtual void SetFaccao(Faccao faccao)
        {
            Faccao = faccao ?? throw new Exception("Facção é obrigatorio para Membro");
        }

        public virtual void SetDataBatismo(DateTime? dataBatismo)
        {
            if (dataBatismo is null)
                throw new Exception("Data de batismo é obrigatoria");
            DataBatismo = dataBatismo.Value;
        }

        public virtual void SetDataCadastro(DateTime? dataCadastro)
        {
            if (dataCadastro is null)
                throw new Exception("Data de cadastro é obrigatoria");
            DataCadastro = dataCadastro.Value;
        }

        public virtual void SetReferencia(string referencia)
        {
            if (string.IsNullOrWhiteSpace(referencia))
                throw new Exception("Referência do Membro é obrigatorio");
            if (referencia.Length > 100)
                throw new Exception("Referência não pode possuir mais de 100 caracteres");
            Referencia = referencia;
        }

        public virtual void SetMatricula(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula))
                throw new Exception("Matricula do Membro é obrigatorio");
            if (matricula.Length > 100)
                throw new Exception("Matricula não pode possuir mais de 100 caracteres");
            Matricula = matricula;
        }

        public virtual void SetFoto(string foto)
        {
            if (string.IsNullOrWhiteSpace(foto))
                throw new Exception("Foto do Membro é obrigatorio");
            Foto = foto;
        }

        public virtual void SetCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new Exception("CPF do Membro é obrigatorio");
            if (cpf.Length > 11)
                throw new Exception("CPF do Membro não pode possuir mais de 11 caracteres");
            CPF = cpf;
        }

        public virtual void SetNomeMae(string nomeMae)
        {
            if (string.IsNullOrWhiteSpace(nomeMae))
                throw new Exception("Nome da mãe é obrigatorio");
            if (nomeMae.Length > 100)
                throw new Exception("Nome da mãe não pode possuir mais de 100 caracteres");
            NomeMae = nomeMae;
        }

        public virtual void SetObito(bool obito)
        {
            Obito = obito;
        }

        public virtual void SetDataObito(DateTime? dataObito)
        {
            DataObito = dataObito.Value;
        }

        public virtual void SetLocalObito(string localObito)
        {
            if (localObito.Length > 200)
                throw new Exception("Local de Óbito não pode possuir mais de 200 caracteres");
            LocalObito = localObito;
        }

        public virtual void SetCaracteristicas(string caracteristicas)
        {
            if (string.IsNullOrWhiteSpace(caracteristicas))
                throw new Exception("Caracteristicas do Membro é obrigatorio");
            if (caracteristicas.Length > 200)
                throw new Exception("Caracteristicas do Membro não pode possuir mais de 200 caracteres");
            Caracteristicas = caracteristicas;
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
