using financeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace financeApp.Infrastructure.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("varchar(255)");
        
        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("varchar(255)");
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("varchar(255)");
        
        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnType("varchar(255)");
    }
}