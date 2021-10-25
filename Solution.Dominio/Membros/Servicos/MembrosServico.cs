using System;

using Solution.Dominio.Membros.Repositorios;
using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.Membros.Servicos.Interfaces;
using Solution.Dominio.Faccoes.Entidades;

namespace Solution.Dominio.Membros.Servicos
{
    public class MembrosServico : IMembrosServico
    {
        private readonly IMembrosRepositorio membrosRepositorio;

        public MembrosServico(IMembrosRepositorio membrosRepositorio)
        {
            this.membrosRepositorio = membrosRepositorio;
        }
        public Membro Validar(long? codigo)
        {
            if (codigo is null)
                throw new Exception("Codigo do membro invalido");
            Membro entidade = membrosRepositorio.Recuperar(codigo.Value);
            if (entidade is null)
                throw new Exception("Membro não encontrado");
            return entidade;
        }

        public Membro Inserir(string nome, string nomeVulgo, int idade, Faccao faccao, DateTime dataBatismo, DateTime dataCadastro, string referencia, string matricula, string foto, string cpf, string nomeMae, bool obito, DateTime dataObito, string localObito, string caracteristicas, bool isDeleted = false)
        {
            Membro entidade = new(nome, nomeVulgo, idade, faccao, dataBatismo, dataCadastro, referencia, matricula, foto, cpf, nomeMae, obito, dataObito, localObito, caracteristicas, isDeleted, null, string.Empty);
            return membrosRepositorio.Inserir(entidade);
        }

        public Membro Editar(long? codigo, string nome, string nomeVulgo, int idade, Faccao faccao, DateTime dataBatismo, DateTime dataCadastro, string referencia, string matricula, string foto, string cpf, string nomeMae, bool obito, DateTime dataObito, string localObito, string caracteristicas, bool isDeleted, DateTime? dataDesativacao, string motivoDesativacao)
        {
            Membro entidade = Validar(codigo);

            if (nome is not null && nome != entidade.Nome)
            {
                entidade.SetNome(nome);
            }
            if (nomeVulgo is not null && nomeVulgo != entidade.NomeVulgo)
            {
                entidade.SetNomeVulgo(nomeVulgo);
            }
            if (idade != 0 && idade != entidade.Idade)
            {
                entidade.SetIdade(idade);
            }
            if (faccao is not null && faccao != entidade.Faccao)
            {
                entidade.SetFaccao(faccao);
            }
            if (!string.IsNullOrEmpty(dataBatismo.ToString()) && dataBatismo != entidade.DataBatismo)
            {
                entidade.SetDataBatismo(dataBatismo);
            }
            if (!string.IsNullOrEmpty(dataCadastro.ToString()) && dataCadastro != entidade.DataCadastro)
            {
                entidade.SetDataCadastro(dataCadastro);
            }
            if (referencia is not null && referencia != entidade.Referencia)
            {
                entidade.SetReferencia(referencia);
            }
            if (matricula is not null && matricula != entidade.Matricula)
            {
                entidade.SetMatricula(matricula);
            }
            if (cpf is not null && cpf != entidade.CPF)
            {
                entidade.SetCpf(cpf);
            }
            if (nomeMae is not null && cpf != entidade.NomeMae)
            {
                entidade.SetNomeMae(nomeMae);
            }
            if (obito == true || obito == false)
            {
                entidade.SetObito(obito);
            }
            if (!string.IsNullOrEmpty(dataObito.ToString()) && dataObito != entidade.DataObito)
            {
                entidade.SetDataObito(dataObito);
            }
            if (localObito is not null && localObito != entidade.LocalObito)
            {
                entidade.SetLocalObito(localObito);
            }
            if (caracteristicas is not null && caracteristicas != entidade.Caracteristicas)
            {
                entidade.SetCaracteristicas(caracteristicas);
            }
            if (isDeleted == true || isDeleted == false)
            {
                entidade.SetIsDeleted(isDeleted);

                if (isDeleted == true)
                {
                    entidade.SetMotivoDesativacao(motivoDesativacao, DateTime.Now);
                }

            }

            return membrosRepositorio.Editar(entidade);
        }

        public void Excluir(long codigo)
        {
            Membro entidade = Validar(codigo);
            membrosRepositorio.Excluir(entidade);
        }

    }
}
