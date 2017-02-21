namespace DataAccess.EF
{
    using Model;
    using Model.Repositories;
    using DataAccess.EF.Repositories;
    using System;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DepartmentContext _departmentContext;
        private readonly UserContext _userContext;

        public UnitOfWork(DepartmentContext departmentContext, UserContext userContext)
        {
            if(departmentContext == null)
            {
                throw new ArgumentNullException(nameof(departmentContext));
            }

            if(userContext == null)
            {
                throw new ArgumentNullException(nameof(userContext));
            }

            this._departmentContext = departmentContext;
            this._userContext = userContext;
            this.Departments = new DepartmentRepository(this._departmentContext);
            this.Users = new UserRepository(this._userContext);
        }

        public IDepartmentRepository Departments { get; private set; }
        public IUserRepository Users { get; private set; }

        public void Commit()
        {
            this._departmentContext.SaveChanges();
            this._userContext.SaveChanges();
        }

        public void Dispose()
        {
            this._departmentContext.Dispose();
            this._userContext.Dispose();
        }
    }
}
