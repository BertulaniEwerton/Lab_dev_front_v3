using Solution.DataTransfer.Quebradas.Requests;
using Solution.DataTransfer.Quebradas.Responses;
using Solution.DataTransfer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Aplicacao.Quebradas.Servicos.Interfaces
{
    public interface IQuebradasAppServicos
    {
        QuebradaResponse Recuperar(long id);
        PaginacaoConsulta<QuebradaResponse> Listar(QuebradaListarRequest request);
        QuebradaResponse Inserir(QuebradaInserirRequest request);
        QuebradaResponse Editar(long id, QuebradaEditarRequest request);
        void Deletar(long id);
    }
}
