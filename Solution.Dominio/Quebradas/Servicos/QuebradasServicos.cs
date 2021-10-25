using Solution.Dominio.Quebradas.Entidades;
using Solution.Dominio.Quebradas.Repositorios;
using Solution.Dominio.Quebradas.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Dominio.Quebradas.Servicos
{
    public class QuebradasServicos : IQuebradasServicos
    {
        private readonly IQuebradasRepositorio quebradaRepositorio;

        public QuebradasServicos(IQuebradasRepositorio quebradaRepositorio)
        {
            this.quebradaRepositorio = quebradaRepositorio;
        }

        public Quebrada Validar(long? codigo)
        {
            if (codigo is null)
                throw new Exception("Codigo de faccao invalido");
            Quebrada entidade = quebradaRepositorio.Recuperar(codigo.Value);
            if (entidade is null)
                throw new Exception("Quebrada não encontrada");
            return entidade;
        }

        public Quebrada Inserir(string telefone, string endereco, string bairro, string cidade, string uf, string origem, bool isDeleted = false)
        {
            Quebrada entidade = new(telefone, endereco, bairro, cidade, uf, origem, isDeleted, null, string.Empty);
            return quebradaRepositorio.Inserir(entidade);
        }

        public Quebrada Editar(long? codigo, string telefone, string endereco, string bairro, string cidade, string uf, string origem, bool isDeleted, DateTime? dataDesativacao, string motivoDesativacao)
        {
            Quebrada entidade = Validar(codigo);

            if (telefone is not null && telefone != entidade.Telefone)
            {
                entidade.SetTelefone(telefone);
            }
            if (endereco is not null && endereco != entidade.Endereco)
            {
                entidade.SetEndereco(endereco);
            }
            if (bairro is not null && bairro != entidade.Bairro)
            {
                entidade.SetBairro(bairro);
            }
            if (cidade is not null && cidade != entidade.Cidade)
            {
                entidade.SetCidade(cidade);
            }
            if (uf is not null && uf != entidade.Uf)
            {
                entidade.SetUF(uf);
            }
            if (origem is not null && origem != entidade.Origem)
            {
                entidade.SetOrigem(origem);
            }
            if (isDeleted == true || isDeleted == false)
            {
                entidade.SetIsDeleted(isDeleted);

                if (isDeleted == true)
                {
                    entidade.SetMotivoDesativacao(motivoDesativacao, DateTime.Now);
                }

            }

            return quebradaRepositorio.Editar(entidade);
        }

        public void Excluir(long codigo)
        {
            Quebrada entidade = Validar(codigo);
            quebradaRepositorio.Excluir(entidade);
        }


    }
}
