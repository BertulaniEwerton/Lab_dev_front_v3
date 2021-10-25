using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;

using Solution.Dominio.ProcessosCautelares.Entidades;

namespace Solution.Infra.ProcessosCautelares.Mapeamentos
{
    public class ProcessosCautelaresMap : ClassMap<ProcessoCautelar>
    {
        public ProcessosCautelaresMap()
        {
            Schema("DELTA");
            Table("PROCESSOSCAUTELARES");
            CompositeId()
                .KeyReference(x => x.Cautelar, "IDCAUTELAR")
                .KeyReference(x => x.Processo, "IDPROOCESSO");

            Map(x => x.DataInicio).Column("DATAINICIO");
            Map(x => x.DataFim).Column("DATAFIM");

            ReadOnly();
        }
    }
}
