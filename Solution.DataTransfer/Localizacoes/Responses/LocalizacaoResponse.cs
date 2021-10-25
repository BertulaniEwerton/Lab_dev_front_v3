using Solution.DataTransfer.Membros.Responses;
using Solution.DataTransfer.Quebradas.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DataTransfer.Localizacoes.Responses
{
    public class LocalizacaoResponse
    {
        public MembroResponse membro { get; set; }
        public QuebradaResponse quebrada { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
