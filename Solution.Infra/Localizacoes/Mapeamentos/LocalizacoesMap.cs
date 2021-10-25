using FluentNHibernate.Mapping;

using Solution.Dominio.Localizacoes.Entidades;

namespace Solution.Infra.Localizacoes.Mapeamentos
{
    public class LocalizacoesMap : ClassMap<Localizacao>
    {
        public LocalizacoesMap()
        {
            Schema("DELTA");
            Table("LOCALIZACAO");
            CompositeId()
                .KeyReference(x => x.Membro, "IDMEMBRO")
                .KeyReference(x => x.Quebrada, "IDQUEBRADA");

            Map(x => x.DataFim).Column("DATAFIM");
            Map(x => x.DataInicio).Column("DATAINICIO");

            ReadOnly();
        }
    }
}
