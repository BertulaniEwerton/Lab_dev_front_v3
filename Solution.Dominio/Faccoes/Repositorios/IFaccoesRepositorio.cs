using System;
using System.Linq;
using System.Linq.Expressions;
using Solution.Dominio.Faccoes.Entidades;

namespace Solution.Dominio.Faccoes.Repositorios
{
    public interface IFaccoesRepositorio
    {
        IQueryable<Faccao> Query();
        Faccao Recuperar(long id);
        Faccao Recuperar(Expression<Func<Faccao, bool>> expression);
        Faccao Inserir(Faccao entidade);
        Faccao Editar(Faccao entidade);
        void Excluir(Faccao entidade);
    }
}
