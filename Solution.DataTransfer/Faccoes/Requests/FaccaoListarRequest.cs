using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.Utils;
using System.Collections.Generic;

namespace Solution.DataTransfer.Faccoes.Requests
{
    public class FaccaoListarRequest : PaginacaoRequest
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string UFOrigem { get; set; }
        public string AnoOrigem { get; set; }
        public string NomeLider { get; set; }
        public bool IsDeleted { get; set; }
        public IList<Membro> Membros { get; set; }
        public FaccaoListarRequest() : base(1, 10, "Codigo") { }
    }
}
