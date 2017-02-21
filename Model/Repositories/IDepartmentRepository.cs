namespace Model.Repositories
{
    using Model.Domain;
    using System.Collections.Generic;

    public interface IDepartmentRepository : IRepository<Department>
    {
        // Department GetDepartmentsWithUsers(int id);
    }
}
