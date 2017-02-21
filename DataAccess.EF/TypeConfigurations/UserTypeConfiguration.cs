namespace DataAccess.EF.TypeConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using DataAccess.EF.Util;
    using Model.Domain;

    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserTypeConfiguration()
        {
            // Department Title should be unique
            Property(p => p.UserName)
                .HasUniqueIndexAnnotation("UK_Users__UserName", 1);

            //Non-nullable columns
            Property(p => p.UserName)
                .IsRequired();

            // Mapping UserId to Id column in database as per requirements
            // Map(m => m.Property(p => p.UserId).HasColumnName("Id"));
            Map(m => m.ToTable("Users"));

            // One Department to many Users relation
            //HasRequired(d => d.Department)
            //    .WithMany(d => d.Users)
            //    .HasForeignKey(u => u.DepartmentId)
            //    .WillCascadeOnDelete(true);
        }
    }
}
