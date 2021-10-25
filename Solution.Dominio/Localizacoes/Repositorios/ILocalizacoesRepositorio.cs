using Solution.Dominio.Localizacoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Dominio.Localizacoes.Repositorios
{
    public interface ILocalizacoesRepositorio
    {
        IQueryable<Localizacao> Query();
        Localizacao Recuperar(long id);
        Localizacao Recuperar(Expression<Func<Localizacao, bool>> expression);
        Localizacao Inserir(Localizacao entidade);
        Localizacao Editar(Localizacao entidade);
        void Excluir(Localizacao entidade);
    }
}
