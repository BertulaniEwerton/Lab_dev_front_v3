using Solution.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DataTransfer.Localizacoes.Requests
{
    public class LocalizacaoListarRequest : PaginacaoRequest
    {
        public long? CodigoMembro { get; set; }
        public long? CodigoQuebrada { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFIm { get; set; }

        public LocalizacaoListarRequest() : base(1, 10, "Codigo") { }

    }
}
