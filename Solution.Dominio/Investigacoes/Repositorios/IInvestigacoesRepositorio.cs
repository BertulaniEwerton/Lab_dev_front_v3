using System;
using System.Linq;
using System.Linq.Expressions;

using Solution.Dominio.Investigacoes.Entidades;

namespace Solution.Dominio.Investigacoes.Repositorios
{
    public interface IInvestigacoesRepositorio
    {
        IQueryable<Investigacao> Query();
        Investigacao Recuperar(long id);
        Investigacao Recuperar(Expression<Func<Investigacao, bool>> expression);
        Investigacao Editar(Investigacao entidade);
        Investigacao Inserir(Investigacao entidade);
        void Excluir(Investigacao entidade);
    }
}
