using NHibernate;
using Solution.Dominio.Localizacoes.Entidades;
using Solution.Dominio.Localizacoes.Repositorios;
using Solution.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Infra.Localizacoes.Repositorios
{
    public class LocalizacoesRepositorio : RepositorioNhibernateBase<Localizacao>, ILocalizacoesRepositorio
    {
        public LocalizacoesRepositorio(ISession session) : base(session)
        {
        }

        public new Localizacao Recuperar(long id)
        {
            return Recuperar(x => x.Membro.Id == id);
        }
    }
}
