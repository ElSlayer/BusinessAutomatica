namespace DataAccess.EF.Util
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration.Configuration;

    public static class MappingExtensions
    {
        //public static PrimitivePropertyConfiguration IsUnique(this PrimitivePropertyConfiguration configuration)
        //{
        //	return configuration.HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute { IsUnique = true }));
        //}

        public static PrimitivePropertyConfiguration HasUniqueIndexAnnotation(
            this PrimitivePropertyConfiguration property,
            string indexName,
            int columnOrder
            )
        {
            var indexAttribute = new IndexAttribute(indexName, columnOrder) { IsUnique = true };
            var indexAnnotation = new IndexAnnotation(indexAttribute);

            return property.HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
        }
    }
}
