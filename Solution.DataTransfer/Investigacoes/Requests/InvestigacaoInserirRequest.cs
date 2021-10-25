using System;

namespace Solution.DataTransfer.Investigacoes.Requests
{
    public class InvestigacaoInserirRequest
    {
        public long CodigoMembro { get; set; }
        public string TituloOperacao { get; set; }
        public string PromotoriaVara { get; set; }
        public string Estado { get; set; }
        public string Prova { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInvestigacao { get; set; }
    }
}
