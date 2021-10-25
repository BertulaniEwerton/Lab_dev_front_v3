using System.Collections.Generic;

using Solution.Dominio.Membros.Entidades;

namespace Solution.Dominio.Padrinhos.Entidades
{
    public class Padrinho
    {
        public virtual long Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Apelido { get; protected set; }
        public virtual IList<Membro> Membros { get; protected set; }

    }
}
