using Solution.Dominio.Faccoes.Entidades;
using Solution.Dominio.Membros.Entidades;
using System;

namespace Solution.Dominio.Membros.Servicos.Interfaces
{
    public interface IMembrosServico
    {
        Membro Validar(long? codigo);
        Membro Inserir(string nome, string nomeVulgo, int idade, Faccao faccao, DateTime dataBatismo, DateTime dataCadastro, string referencia, string matricula, string foto, string cpf, string nomeMae, bool obito, DateTime dataObito, string localObito, string caracteristicas, bool isDeleted);
        Membro Editar(long? codigo, string nome, string nomeVulgo, int idade, Faccao faccao, DateTime dataBatismo, DateTime dataCadastro, string referencia, string matricula, string foto, string cpf, string nomeMae, bool obito, DateTime dataObito, string localObito, string caracteristicas, bool isDeleted, DateTime? dataDesativacao, string motivoDesativacao);
        void Excluir(long codigo);
    }
}
