using Solution.Dominio.Membros.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Solution.Dominio.Membros.Repositorios
{
    public interface IMembrosRepositorio
    {
        IQueryable<Membro> Query();
        Membro Recuperar(long id);
        Membro Recuperar(Expression<Func<Membro, bool>> expression);
        Membro Inserir(Membro entidade);
        Membro Editar(Membro entidade);
        void Excluir(Membro entidade);
    }
}
