using NHibernate;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;

namespace Solution.Infra.Utils
{
    public class RepositorioNhibernateBase<T>
    {
        public ISession Session { get; }

        public RepositorioNhibernateBase(ISession session)
        {
            Session = session;
        }

        public virtual IQueryable<T> Query()
        {
            return Session.Query<T>();
        }

        public virtual T Recuperar(long id)
        {
            return Session.Get<T>(id);
        }

        public T Recuperar(Expression<Func<T, bool>> expression)
        {
            return Query().SingleOrDefault(expression);
        }

        public T Salvar(T entidade)
        {
            Session.SaveOrUpdate(entidade);
            Session.Flush();
            return entidade;
        }

        public T Editar(T entidade)
        {
            Session.Update(entidade);
            return entidade;
        }

        public void Excluir(T entidade)
        {
            Session.Delete(entidade);
        }

        public void Excluir(IEnumerable<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                Excluir(entidade);
            }
        }

        public T Inserir(T entidade)
        {
            Session.Save(entidade);
            return entidade;
        }

        public IEnumerable<T> Inserir(IEnumerable<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                Session.Save(entidade);
            }
            return entidades;
        }
    }
}
