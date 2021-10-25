using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;

using Solution.Dominio.Padrinhos.Entidades;

namespace Solution.Infra.Padrinhos.Mapeamentos
{
    public class PadrinhosMap : ClassMap<Padrinho>
    {
        public PadrinhosMap()
        {
            Schema("DELTA");
            Table("PADRINHOS");
            Id(x => x.Id).Column("IDPADRINHO");
            Map(x => x.Nome).Column("NOME");
            Map(x => x.Apelido).Column("APELIDO");
            HasManyToMany(x => x.Membros)
                .Schema("DELTA")
                .Table("APADRINHAMENTO")
                .ChildKeyColumn("IDPADRINHO")
                .ParentKeyColumn("IDMEMBRO")
                .Fetch.Subselect();

            ReadOnly();
        }
    }
}
