namespace DataAccess.EF.Repositories
{
    using System;
    using System.Collections.Generic;
    using Model.Domain;
    using Model.Repositories;
    using System.Data.Entity;
    using System.Linq;

    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DepartmentContext context) 
            : base(context)
        {

        }

        public DepartmentContext GetContext()
        {
            return Context as DepartmentContext;
        }

        //public Department GetDepartmentsWithUsers(int id)
        //{
        //    return GetContext().Departments
        //        .Include(d => d.Users)
        //        .SingleOrDefault(a => a.Id == id);            
        //}

        //public IEnumerable<Department> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(Department entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Department entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Department GetById(int Id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
