namespace DataAccess.EF
{
    using Model.Domain;
    using System.Data.Entity;
    using TypeConfigurations;
    public class DepartmentContext : DbContext
    {
        public DepartmentContext()
            : base("DepartmentDB")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DepartmentContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PersonnelContext>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<PersonnelContext>());
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Department> Departments { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Personnel");

            modelBuilder.Configurations.Add(new DepartmentTypeConfiguration());

            // Default string length 255 (instead of shitty nvarchar(max))
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(255));

            base.OnModelCreating(modelBuilder);
        }
    }
}
