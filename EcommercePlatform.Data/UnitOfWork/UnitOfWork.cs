using ECommercePlatform.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;

        private IDbContextTransaction _transaction;

        public UnitOfWork(ECommerceDbContext context)
        {
             _context = context;
        }
        public async Task BeginTransactions()
        {
            _transaction=await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactions()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task RollBackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
