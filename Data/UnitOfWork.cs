using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Data.Contracts;
using System.Data;
using Application.Context;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CommitAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return await _dataContext.Database.BeginTransactionAsync(isolationLevel);
        }

        public async void DisposeAsync()
        {
            await _dataContext.DisposeAsync();
        }

    }
}