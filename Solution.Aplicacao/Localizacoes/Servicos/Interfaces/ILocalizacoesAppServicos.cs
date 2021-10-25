using Solution.DataTransfer.Localizacoes.Requests;
using Solution.DataTransfer.Localizacoes.Responses;
using Solution.DataTransfer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Aplicacao.Localizacoes.Servicos.Interfaces
{
    public interface ILocalizacoesAppServicos
    {
        LocalizacaoResponse Recuperar(long id);
        PaginacaoConsulta<LocalizacaoResponse> Listar(LocalizacaoListarRequest request);
        LocalizacaoResponse Inserir(LocalizacaoInserirRequest request);
        LocalizacaoResponse Editar(long id, LocalizacaoEditarRequest request);
        void Deletar(long id);
    }
}
