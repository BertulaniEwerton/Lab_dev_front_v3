using Solution.Dominio.Localizacoes.Entidades;
using Solution.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DataTransfer.Quebradas.Requests
{
    public class QuebradaListarRequest : PaginacaoRequest
    {
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Origem { get; set; }
        public bool IsDeleted { get; set; }
        public IList<Localizacao> Localizacoes { get; set; }
        public QuebradaListarRequest() : base(1, 10, "Codigo") { }
    }
}
