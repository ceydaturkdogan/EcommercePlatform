using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {

        Task<int> SaveChangesAsync(); 

        Task BeginTransactions();

        Task CommitTransactions();

        Task RollBackTransaction();
    }
}
