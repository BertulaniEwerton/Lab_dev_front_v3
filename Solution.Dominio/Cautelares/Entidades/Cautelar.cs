using Solution.Dominio.ProcessosCautelares.Entidades;
using System.Collections.Generic;

namespace Solution.Dominio.Cautelares.Entidades
{
    public class Cautelar
    {
        public virtual long Id { get; protected set; }
        public virtual int TempoPena { get; protected set; }
        public virtual string LocalCumprimento { get; protected set; }
        public virtual string UF { get; protected set; }
        public virtual IList<ProcessoCautelar> ProcessosCautelares { get; protected set; }

    }
}
