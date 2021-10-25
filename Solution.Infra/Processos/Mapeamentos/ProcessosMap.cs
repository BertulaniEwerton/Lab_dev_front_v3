using FluentNHibernate.Mapping;

using Solution.Dominio.Processos.Entidades;

namespace Solution.Infra.Processos.Mapeamentos
{
    public class ProcessosMap : ClassMap<Processo>
    {
        public ProcessosMap()
        {
            Schema("DELTA");
            Table("PROCESSOS");
            Id(x => x.Id).Column("IDPROCESSO");
            Map(x => x.NumeroProcesso).Column("NUMEROPROCESSO");
            Map(x => x.UF).Column("UF");
            Map(x => x.Vara).Column("VARA");
            Map(x => x.Artigos).Column("ARTIGOS");
            Map(x => x.Comarca).Column("COMARCA");
            References(x => x.Membro).Column("IDMEMBRO");
            HasMany(x => x.ProcessosCautelares)
                .KeyColumn("IDPROCESSO")
                .Fetch.Subselect();

            ReadOnly();
        }
    }
}
