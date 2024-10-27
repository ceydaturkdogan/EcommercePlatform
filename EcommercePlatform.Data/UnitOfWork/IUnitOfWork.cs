using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> SaveChangesAsync(); //Kaç kayda etki ettiğini geri döner, o yüzden int

        Task BeginTransactions();

        //task asenkron metotların voididir.

        Task CommitTransactions();

        Task RollBackTransaction();
    }
}
