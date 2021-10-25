using NHibernate;

using Solution.Dominio.Investigacoes.Entidades;
using Solution.Dominio.Investigacoes.Repositorios;
using Solution.Infra.Utils;

namespace Solution.Infra.Investigacoes.Repositorios
{
    public class InvestigacoesRepositorio : RepositorioNhibernateBase<Investigacao>, IInvestigacoesRepositorio
    {
        public InvestigacoesRepositorio(ISession session) : base(session)
        {
        }

        public new Investigacao Recuperar(long id)
        {
            return Recuperar(x => x.Id == id);
        }
    }
}
