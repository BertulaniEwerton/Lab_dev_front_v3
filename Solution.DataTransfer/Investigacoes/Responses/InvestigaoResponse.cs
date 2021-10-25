using System;

using Solution.DataTransfer.Membros.Responses;

namespace Solution.DataTransfer.Investigacoes.Responses
{
    public class InvestigaoResponse
    {
        public long Id { get; set; }
        public MembroResponse Membro { get; set; }
        public string TituloOperacao { get; set; }
        public string PromotoriaVara { get; set; }
        public string Estado { get; set; }
        public string Prova { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInvestigacao { get; set; }
    }
}
