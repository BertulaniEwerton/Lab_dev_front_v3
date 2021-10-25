using FluentNHibernate.Mapping;

using Solution.Dominio.Dossies.Entidades;

namespace Solution.Infra.Dossies.Mapeamentos
{
    public class DossiesMap : ClassMap<Dossie>
    {
        public DossiesMap()
        {
            Schema("DELTA");
            Table("DOSSIES");
            Id(x => x.Id).Column("IDDOSSIE");
            Map(x => x.Descricao).Column("DESCRICAO");
            Map(x => x.DataAtualizacao).Column("DATAATUALIZACAO");
            Map(x => x.DataAcesso).Column("DATAACESSO");
            Map(x => x.Blob).Column("BLOB");
            Map(x => x.Link).Column("LINK");
            References(x => x.Membro).Column("IDMEMBRO");

            ReadOnly();
        }
    }
}
