using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.Quebradas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DataTransfer.Localizacoes.Requests
{
    public class LocalizacaoEditarRequest
    {
        public Membro Membro { get; set; }
        public Quebrada Quebrada { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
