using System;
using System.Collections.Generic;

using Solution.Dominio.Cautelares.Entidades;
using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.Processos.Entidades;
using Solution.Dominio.Quebradas.Entidades;

namespace Solution.Dominio.ProcessosCautelares.Entidades
{
    public class ProcessoCautelar
    {
        public virtual Cautelar Cautelar { get; protected set; }
        public virtual Processo Processo { get; protected set; }
        public virtual DateTime DataInicio { get; protected set; }
        public virtual DateTime DataFim { get; protected set; }

        public override bool Equals(object obj)
        {
            return obj is ProcessoCautelar processoCautelar &&
                   Cautelar.Id == processoCautelar.Cautelar.Id  &&
                   Processo.Id == processoCautelar.Processo.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Cautelar.Id, Processo.Id);
        }
    }
}
