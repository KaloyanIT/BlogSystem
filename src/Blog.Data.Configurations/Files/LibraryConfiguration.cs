namespace Blog.Data.Configurations.Files
{
    using Models.Files;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Blog.Infrastructure.Constants;
    using Blog.Data.Models.Links;

    public class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.ToTable(DataBaseConstants.LibraryTableName);        
        }
    }
}
