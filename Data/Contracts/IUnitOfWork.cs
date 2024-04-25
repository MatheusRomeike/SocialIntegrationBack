using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Data.Contracts
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void DisposeAsync();
    }
}