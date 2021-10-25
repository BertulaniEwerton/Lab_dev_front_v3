using Solution.Dominio.Quebradas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Dominio.Quebradas.Servicos.Interfaces
{
    public interface IQuebradasServicos
    {
        Quebrada Validar(long? codigo);
        Quebrada Inserir(string telefone, string endereco, string bairro, string cidade, string uf, string origem, bool isDeleted);
        Quebrada Editar(long? codigo, string telefone, string endereco, string bairro, string cidade, string uf, string origem, bool isDeleted, DateTime? dataDesativacao, string motivoDesativacao);
        void Excluir(long codigo);

    }
}
