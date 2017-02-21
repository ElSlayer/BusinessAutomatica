namespace DataAccess.EF.Repositories
{
    using System;
    using System.Collections.Generic;
    using Model.Domain;
    using Model.Repositories;
    using System.Data.Entity;

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserContext context) 
            : base(context)
        {

        }

        public UserContext GetContext()
        {
            return Context as UserContext;
        }

        //public IEnumerable<User> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(User entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(User entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public User GetById(int Id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
