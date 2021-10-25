using System.Collections.Generic;

using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.ProcessosCautelares.Entidades;

namespace Solution.Dominio.Processos.Entidades
{
    public class Processo
    {
        public virtual long Id { get; protected set; }
        public virtual string Vara { get; protected set; }
        public virtual string Comarca { get; protected set; }
        public virtual string UF { get; protected set; }
        public virtual string Artigos { get; protected set; }
        public virtual string NumeroProcesso { get; protected set; }
        public virtual Membro Membro { get; protected set; }
        public virtual IList<ProcessoCautelar> ProcessosCautelares { get; protected set; }

    }
}
