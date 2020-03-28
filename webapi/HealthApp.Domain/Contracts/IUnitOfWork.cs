using System;

namespace HealthApp.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
