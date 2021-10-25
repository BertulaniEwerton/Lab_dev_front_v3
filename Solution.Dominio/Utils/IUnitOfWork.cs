using System;

namespace Solution.Dominio.Utils
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Iniciar uma transação no banco de dados
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Desfazer as alterações realizadas em uma transação
        /// </summary>
        void Rollback();

        /// <summary>
        /// Aplicar as alterações realizadas em uma transação
        /// </summary>
        void Commit();

        /// <summary>
        /// Executa a limpeza completa na sessão
        /// </summary>
        void LimparSessao();

        /// <summary>
        /// Força o flush da sessão
        /// </summary>
        void FlushSessao();
    }
}
