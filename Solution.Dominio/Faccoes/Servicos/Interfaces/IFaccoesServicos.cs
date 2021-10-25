using Solution.Dominio.Faccoes.Entidades;
using System;

namespace Solution.Dominio.Faccoes.Services.Interfaces
{
    public interface IFaccoesServicos
    {
        Faccao Validar(long? codigo);
        Faccao Inserir(string nome, string sigla, string ufOrigem, string anoOrigem, string nomeLider, bool isDeleted);
        Faccao Editar(long? codigo, string nome, string sigla, string ufOrigem, string anoOrigem, string nomeLider, bool isDeleted, DateTime? dataDesativacao, string motivoDesativacao);
        void Excluir(long codigo);

    }
}
