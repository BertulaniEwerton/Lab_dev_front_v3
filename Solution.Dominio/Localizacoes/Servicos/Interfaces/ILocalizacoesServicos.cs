using Solution.Dominio.Localizacoes.Entidades;
using Solution.Dominio.Membros.Entidades;
using Solution.Dominio.Quebradas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Dominio.Localizacoes.Servicos.Interfaces
{
    public interface ILocalizacoesServicos
    {
        Localizacao Validar(long? codigo);
        Localizacao Inserir(Membro membro, Quebrada quebrada, DateTime dataInicio, DateTime dataFim);
        Localizacao Editar(long? codigo, Membro membro, Quebrada quebrada, DateTime? dataInicio, DateTime? dataFim);
        void Excluir(long codigo);
    }
}
