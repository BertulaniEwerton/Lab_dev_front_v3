using NHibernate;
using Solution.Dominio.Quebradas.Entidades;
using Solution.Dominio.Quebradas.Repositorios;
using Solution.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Infra.Quebradas.Repositorios
{
    public class QuebradasRepositorio : RepositorioNhibernateBase<Quebrada>, IQuebradasRepositorio
    {
        public QuebradasRepositorio(ISession session) : base(session)
        {
        }

        public new Quebrada Recuperar(long id)
        {
            return Recuperar(x => x.Id == id);
        }
    }
}
