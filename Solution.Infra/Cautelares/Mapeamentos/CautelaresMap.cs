using FluentNHibernate.Mapping;

using Solution.Dominio.Cautelares.Entidades;

namespace Solution.Infra.Cautelares.Mapeamentos
{
    public class CautelaresMap : ClassMap<Cautelar>
    {
        public CautelaresMap()
        {
            Schema("DELTA");
            Table("CAUTELAR");
            Id(x => x.Id).Column("IDCAUTELAR");
            Map(x => x.UF).Column("UF");
            Map(x => x.TempoPena).Column("TEMPOPENA");
            Map(x => x.LocalCumprimento).Column("LOCALCUMPRIMENTO");

            HasMany(x => x.ProcessosCautelares)
                .KeyColumn("IDCAUTELAR")
                .Fetch.Subselect();

            ReadOnly();
        }
    }
}
