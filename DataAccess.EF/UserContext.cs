namespace DataAccess.EF
{
    using Model.Domain;
    using System.Data.Entity;
    using TypeConfigurations;
    public class UserContext : DbContext
    {
        public UserContext()
            : base("UserDB")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<UserContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PersonnelContext>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<PersonnelContext>());
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Personnel");

            modelBuilder.Configurations.Add(new UserTypeConfiguration());

            // Default string length 255 (instead of shitty nvarchar(max))
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(255));

            base.OnModelCreating(modelBuilder);
        }
    }
}
