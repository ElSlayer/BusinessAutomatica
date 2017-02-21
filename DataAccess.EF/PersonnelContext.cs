namespace DataAccess.EF
{
    using Model.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Reflection;

    [Obsolete]
    public class PersonnelContext : DbContext
    {
        public PersonnelContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PersonnelContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PersonnelContext>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<PersonnelContext>());
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Personnel");

            // Look for types that derived from EntityTypeConfiguration, create their exemplars and add those to modelBuilder'а
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null
                            && type.BaseType.IsGenericType
                            && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)
                            );
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            // Default string length 255 (instead of shitty nvarchar(max))
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(255));

            base.OnModelCreating(modelBuilder);
        }
    }
}
