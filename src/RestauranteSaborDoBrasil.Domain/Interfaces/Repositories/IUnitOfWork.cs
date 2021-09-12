using System;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();

        Task<bool> CommitAsync();
    }
}