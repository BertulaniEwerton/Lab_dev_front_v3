using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DataTransfer.Localizacoes.Requests
{
    public class LocalizacaoInserirRequest
    {
        public long CodigoMembro { get; set; }
        public long CodigoQuebrada { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
