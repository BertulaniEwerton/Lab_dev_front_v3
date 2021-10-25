using FluentNHibernate.Mapping;

using Solution.Dominio.Investigacoes.Entidades;

namespace Solution.Infra.Investigacoes.Mapeamentos
{
    public class InvestigacoesMap : ClassMap<Investigacao>
    {
        public InvestigacoesMap()
        {
            Schema("DELTA");
            Table("INVESTIGACOES");
            Id(x => x.Id).Column("IDINVESTIGACOES");
            Map(x => x.Estado).Column("ESTADO");
            Map(x => x.PromotoriaVara).Column("PROMOTORIAVARA");
            Map(x => x.Prova).Column("PROVA");
            Map(x => x.TituloOperacao).Column("TITULOOPERACAO");
            Map(x => x.Descricao).Column("DESCRICAO");
            Map(x => x.DataInvestigacao).Column("DATAINVESTIGACAO");
            References(x => x.Membro).Column("IDMEMBRO");
        }
    }
}
