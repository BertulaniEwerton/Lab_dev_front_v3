using System;

using Solution.Dominio.Investigacoes.Entidades;
using Solution.Dominio.Membros.Entidades;

namespace Solution.Dominio.Investigacoes.Servicos.Interfaces
{
    public interface IInvestigacoesServico
    {
        Investigacao Validar(long? codigo);
        Investigacao Inserir(Membro membro, string tituloOperacao, string promotoriaVara, string estado, string prova, string descricao, DateTime? dataInvestigacao);
        Investigacao Editar(long? codigo, string tituloOperacao, string promotoriaVara, string prova, string descricao);
        void Excluir(long codigo);
    }
}
