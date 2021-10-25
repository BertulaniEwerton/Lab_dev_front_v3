using Solution.Dominio.Localizacoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DataTransfer.Quebradas.Responses
{
    public class QuebradaResponse
    {
        public long Id { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Origem { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DataDesativacao { get; set; }
        public string MotivoDesativacao { get; set; }
        public IList<Localizacao> Localizacoes { get; set; }
    }
}
