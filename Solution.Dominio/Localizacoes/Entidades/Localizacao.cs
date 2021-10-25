using System;
using System.Collections.Generic;

using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.Quebradas.Entidades;

namespace Solution.Dominio.Localizacoes.Entidades
{
    public class Localizacao
    {
        public virtual Membro Membro { get; protected set; }
        public virtual Quebrada Quebrada { get; protected set; }
        public virtual DateTime DataInicio { get; protected set; }
        public virtual DateTime DataFim { get; protected set; }

        public override bool Equals(object obj)
        {
            return obj is Localizacao localizacao &&
                   Membro.Id == localizacao.Membro.Id &&
                   Quebrada.Id == localizacao.Quebrada.Id;
        }

        public Localizacao() { }

        public Localizacao(Membro membro, Quebrada quebrada, DateTime dataInicio, DateTime dataFim)
        {
            SetMembro(membro);
            SetQuebrada(quebrada);
            SetDataInicio(dataInicio);
            SetDataFim(dataFim);
        }

        public virtual void SetMembro(Membro membro)
        {
            Membro = membro ?? throw new Exception("Membro é obrigatorio para localizacao");
        }

        public virtual void SetQuebrada(Quebrada quebrada)
        {
            Quebrada = quebrada ?? throw new Exception("Quebrada é obrigatorio para localizacao");
        }

        public virtual void SetDataInicio(DateTime? dataInicio)
        {
            if (dataInicio is null)
                throw new Exception("Data de inicio é obrigatoria");
            DataInicio = dataInicio.Value;
        }

        public virtual void SetDataFim(DateTime? dataFim)
        {
            DataFim = dataFim.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Membro.Id, Quebrada.Id);
        }
    }
}
