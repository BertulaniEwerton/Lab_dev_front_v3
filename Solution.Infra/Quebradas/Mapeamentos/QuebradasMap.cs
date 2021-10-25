using FluentNHibernate.Mapping;

using Solution.Dominio.Quebradas.Entidades;

namespace Solution.Infra.Quebradas.Mapeamentos
{
    public class QuebradasMap : ClassMap<Quebrada>
    {
        public QuebradasMap()
        {
            Schema("DELTA");
            Table("QUEBRADAS");
            Id(x => x.Id).Column("IDQUEBRADA");
            Map(x => x.Telefone).Column("TELEFONE");
            Map(x => x.Endereco).Column("ENDERECO");
            Map(x => x.Bairro).Column("BAIRRO");
            Map(x => x.Cidade).Column("CIDADE");
            Map(x => x.Uf).Column("UF");
            Map(x => x.Origem).Column("ORIGEM");
            Map(x => x.IsDeleted).Column("ISDELETED");
            Map(x => x.MotivoDesativacao).Column("MOTIVODESATIVACAO");
            Map(x => x.DataDesativacao).Column("DATADESATIVACAO");

            HasMany(x => x.Localizacoes)
                .KeyColumn("IDQUEBRADA")
                .Fetch.Subselect();

            //ReadOnly();
        }
    }
}
