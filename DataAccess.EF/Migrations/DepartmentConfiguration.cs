namespace DataAccess.EF.Migrations
{
    using System.Data.Entity.Migrations;
    using Model.Domain;

    internal sealed class DepartmentConfiguration : DbMigrationsConfiguration<DepartmentContext>
    {
        public DepartmentConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DepartmentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Departments.AddOrUpdate(new Department[]
            {
                new Department() { Id = 1, Title = "HR" },
                new Department() { Id = 2, Title = "IT" },
                new Department() { Id = 3, Title = "Sales" }
            });
        }
    }
}
