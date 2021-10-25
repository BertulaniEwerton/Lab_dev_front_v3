using Solution.Dominio.Quebradas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Dominio.Quebradas.Repositorios
{
    public interface IQuebradasRepositorio
    {
        IQueryable<Quebrada> Query();
        Quebrada Recuperar(long id);
        Quebrada Recuperar(Expression<Func<Quebrada, bool>> expression);
        Quebrada Inserir(Quebrada entidade);
        Quebrada Editar(Quebrada entidade);
        void Excluir(Quebrada entidade);
    }
}
