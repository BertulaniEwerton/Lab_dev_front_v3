using System;
using System.Collections.Generic;

using Solution.DataTransfer.Faccoes.Requests;
using Solution.DataTransfer.Faccoes.Responses;
using Solution.DataTransfer.Utils;

namespace Solution.Aplicacao.Faccoes.Servicos.Interfaces
{
    public interface IFaccoesAppServicos
    {
        FaccaoResponse Recuperar(long id);
        PaginacaoConsulta<FaccaoResponse> Listar(FaccaoListarRequest request);
        FaccaoResponse Inserir(FaccaoInserirRequest request);
        FaccaoResponse Editar(long id, FaccaoEditarRequest request);
        void Deletar(long id);
    }
}
