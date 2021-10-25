using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DataTransfer.Faccoes.Requests
{
    public class FaccaoEditarRequest
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string UFOrigem { get; set; }
        public string AnoOrigem { get; set; }
        public string NomeLider { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DataDesativacao { get; set; }
        public string MotivoDesativacao { get; set; }
    }
}
