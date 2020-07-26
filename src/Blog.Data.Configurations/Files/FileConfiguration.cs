namespace Blog.Data.Configurations.Files
{
    using Models.Files;
    using Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Blog.Data.Models.Links;

    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable(DataBaseConstants.FilesTableName);

            builder.HasOne<Library>(s => s.Library)
                .WithMany(g => g.Files)
                .HasForeignKey(f => f.LibraryId);

            builder.HasOne<Link>(s => s.Link)
                .WithMany(g => g.Files)
                .HasForeignKey(f => f.LinkId);
        }
    }
}
