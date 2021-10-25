using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DataTransfer.Quebradas.Requests
{
    public class QuebradaEditarRequest
    {
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Origem { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DataDesativacao { get; set; }
        public string MotivoDesativacao { get; set; }
    }
}
