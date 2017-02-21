namespace Model.Repositories
{
    using Model.Domain;
    using System.Collections.Generic;
    public interface IUserRepository : IRepository<User>
    {
        // Use Find method of generic repository   
        //IEnumerable<User> GetUsersByDepartmentId(int departmentId);
    }
}
