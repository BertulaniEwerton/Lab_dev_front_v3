using Solution.DataTransfer.Membros.Requests;
using Solution.DataTransfer.Membros.Responses;
using Solution.DataTransfer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Aplicacao.Membros.Interfaces
{
    public interface IMembrosAppServicos
    {
        MembroResponse Recuperar(long id);
        PaginacaoConsulta<MembroResponse> Listar(MembroListarRequest request);
        MembroResponse Inserir(MembroInserirRequest request);
        MembroResponse Editar(long id, MembroEditarRequest request);
        void Deletar(long id);
    }
}
