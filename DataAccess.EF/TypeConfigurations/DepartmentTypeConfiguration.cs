namespace DataAccess.EF.TypeConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using DataAccess.EF.Util;
    using Model.Domain;

    public class DepartmentTypeConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentTypeConfiguration()
        {
            // Department Title should be unique
            Property(p => p.Title)
                .HasUniqueIndexAnnotation("UK_Departments__Title", 1);

            //Non-nullable columns
            Property(p => p.Title)
                .IsRequired();

            // Mapping DepartmentId to Id column in database as per requirements
            // Map(m => m.Property(p => p.DepartmentId).HasColumnName("Id"));
            Map(m => m.ToTable("Departments"));
        }
    }
}
