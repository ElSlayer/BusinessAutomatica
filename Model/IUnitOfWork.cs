namespace Model
{
    using Model.Repositories;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Departments { get; }
        IUserRepository Users { get; }
        void Commit();
    }
}
