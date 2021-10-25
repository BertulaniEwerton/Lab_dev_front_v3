using Solution.Dominio.Membros.Entidades;
using System;
using System.Collections.Generic;

namespace Solution.DataTransfer.Faccoes.Responses
{
    public class FaccaoResponse
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string UFOrigem { get; set; }
        public string AnoOrigem { get; set; }
        public string NomeLider { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DataDesativacao { get; set; }
        public string MotivoDesativacao { get; set; }
        public IList<Membro> Membros { get; set; }
    }
}
