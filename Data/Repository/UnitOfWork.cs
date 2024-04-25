using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Data.Contracts;
using System.Data;
using Application.Context;

namespace Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext Context;

        public UnitOfWork(DataContext context)
        {
            Context = context;
        }

        public async Task<bool> CommitAsync()
        {   
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return await Context.Database.BeginTransactionAsync(isolationLevel);
        }

        public async Task DisposeAsync()
        {
            await Context.DisposeAsync();
        }

    }
}