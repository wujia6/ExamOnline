using System;

namespace Domain.IComm
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
