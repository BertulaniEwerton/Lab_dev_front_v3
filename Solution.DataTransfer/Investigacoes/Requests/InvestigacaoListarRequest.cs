using System;          

using Solution.Dominio.Utils;

namespace Solution.DataTransfer.Investigacoes.Requests
{
    public class InvestigacaoListarRequest : PaginacaoRequest
    {
        public long? CodigoMembro { get; set; }
        public string TituloOperacao { get; set; }
        public string PromotoriaVara { get; set; }
        public string Estado { get; set; }
        public string Prova { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public InvestigacaoListarRequest() : base(1,10, "Codigo") {}
    }
}
