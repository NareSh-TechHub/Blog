using BlogApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.API.Models.Configuration
{
    public class PostImageConfiguration : IEntityTypeConfiguration<PostImage>
    {
        public void Configure(EntityTypeBuilder<PostImage> builder)
        {
            builder.HasKey(p => p.ImageId);
            
            builder.Property(p => p.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);
            
            builder.Property(p => p.UploadedOn)
                .IsRequired();
            
            builder.HasOne(p => p.Post)
                .WithMany()
                .HasForeignKey(x=>x.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}