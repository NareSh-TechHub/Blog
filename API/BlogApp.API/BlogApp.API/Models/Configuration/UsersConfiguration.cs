using BlogApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.API.Models.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(200);
            
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(30);
            
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(30);
            
            builder.HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(x=>x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}