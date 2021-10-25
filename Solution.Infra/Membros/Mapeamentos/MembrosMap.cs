using FluentNHibernate.Mapping;

using Solution.Dominio.Membros.Entidades;

namespace Solution.Infra.Membros.Mapeamentos
{
    public class MembrosMap : ClassMap<Membro>
    {
        public MembrosMap()
        {
            Schema("DELTA");
            Table("MEMBROS");
            Id(x => x.Id).Column("IDMEMBRO");
            Map(x => x.Idade).Column("IDADE");
            Map(x => x.Nome).Column("NOME");
            Map(x => x.NomeVulgo).Column("NOMEVULGO");
            Map(x => x.NomeMae).Column("NOMEMAE");
            Map(x => x.DataBatismo).Column("DATABATISMO");
            Map(x => x.DataCadastro).Column("DATACADASTRO");
            Map(x => x.CPF).Column("CPF");
            Map(x => x.Matricula).Column("MATRICULA");
            Map(x => x.Foto).Column("FOTO");
            Map(x => x.Referencia).Column("REFERENCIA");
            Map(x => x.Obito).Column("OBITO");
            Map(x => x.LocalObito).Column("LOCALOBITO");
            Map(x => x.DataObito).Column("DATAOBITO");
            Map(x => x.Caracteristicas).Column("CARACTERISTICASFISICAS");
            Map(x => x.IsDeleted).Column("ISDELETED");
            Map(x => x.MotivoDesativacao).Column("MOTIVODESATIVACAO");
            Map(x => x.DataDesativacao).Column("DATADESATIVACAO");
            References(x => x.Faccao).Column("IDFACCAO");

            HasManyToMany(x => x.Padrinhos)
                .Schema("DELTA")
                .Table("APADRINHAMENTO")
                .ChildKeyColumn("IDMEMBRO")
                .ParentKeyColumn("IDPADRINHO")
                .Fetch.Subselect();

            HasMany(x => x.Processos)
                .KeyColumn("IDMEMBRO")
                .Fetch.Subselect();

            HasMany(x => x.Localizacoes)
                .KeyColumn("IDMEMBRO")
                .Fetch.Subselect();

            HasMany(x => x.Investigacoes)
                .KeyColumn("IDMEMBRO");

            HasMany(x => x.Dossies)
                .KeyColumn("IDMEMBRO");

            //ReadOnly();
        }
    }
}
