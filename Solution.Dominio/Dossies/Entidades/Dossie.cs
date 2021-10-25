using System;
using System.Collections.Generic;
using System.IO;

using Solution.Dominio.Membros.Entidades;

namespace Solution.Dominio.Dossies.Entidades
{
    public class Dossie
    {
        public virtual long Id { get; protected set; }
        public virtual Membro Membro { get; protected set; }
        public virtual byte[] Blob { get; protected set; }
        public virtual DateTime DataAtualizacao { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string Link { get; protected set; }
        public virtual DateTime DataAcesso { get; protected set; }
    }
}
