using Solution.Dominio.Localizacoes.Entidades;
using Solution.Dominio.Localizacoes.Repositorios;
using Solution.Dominio.Localizacoes.Servicos.Interfaces;
using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.Quebradas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Dominio.Localizacoes.Servicos
{
    public class LocalizacoesServicos : ILocalizacoesServicos
    {
        private readonly ILocalizacoesRepositorio localizacaoRepositorio;

        public LocalizacoesServicos(ILocalizacoesRepositorio localizacaoRepositorio)
        {
            this.localizacaoRepositorio = localizacaoRepositorio;
        }

        public Localizacao Validar(long? codigo)
        {
            if (codigo is null)
                throw new Exception("Codigo de localizacao invalido");
            Localizacao entidade = localizacaoRepositorio.Recuperar(codigo.Value);
            if (entidade is null)
                throw new Exception("Faccao não encontrada");
            return entidade;
        }

        public Localizacao Inserir(Membro membro, Quebrada quebrada, DateTime dataInicio, DateTime dataFim)
        {
            Localizacao entidade = new(membro, quebrada, dataInicio, dataFim);
            return localizacaoRepositorio.Inserir(entidade);
        }

        public Localizacao Editar(long? codigo, Membro membro, Quebrada quebrada, DateTime? dataInicio, DateTime? dataFim)
        {
            Localizacao entidade = Validar(codigo);

            if (membro is not null && membro != entidade.Membro)
            {
                entidade.SetMembro(membro);
            }

            if (quebrada is not null && quebrada != entidade.Quebrada)
            {
                entidade.SetQuebrada(quebrada);
            }

            if (!(dataInicio is null) && dataInicio != entidade.DataInicio)
            {
                entidade.SetDataInicio(dataInicio);
            }

            if (!(dataFim is null) && dataFim != entidade.DataFim)
            {
                entidade.SetDataFim(dataFim);
            }

            return localizacaoRepositorio.Editar(entidade);

        }

        public void Excluir(long codigo)
        {
            Localizacao entidade = Validar(codigo);
            localizacaoRepositorio.Excluir(entidade);
        }

    }
}
