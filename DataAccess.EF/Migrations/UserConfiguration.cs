namespace DataAccess.EF.Migrations
{
    using System.Data.Entity.Migrations;
    using Model.Domain;

    internal sealed class UserConfiguration : DbMigrationsConfiguration<UserContext>
    {
        public UserConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Users.AddOrUpdate(new User[]
            {
                new User() { Id = 1, DepartmentId = 1, UserName = "Tatiana" },
                new User() { Id = 2, DepartmentId = 1, UserName = "Ivan" },
                new User() { Id = 3, DepartmentId = 1, UserName = "Sergey" },
                new User() { Id = 4, DepartmentId = 2, UserName = "Egor" },
                new User() { Id = 5, DepartmentId = 3, UserName = "Peter" },
                new User() { Id = 6, DepartmentId = 3, UserName = "George" },
            });
        }
    }
}
