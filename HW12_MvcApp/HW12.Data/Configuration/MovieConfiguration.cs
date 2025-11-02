using HW12.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HW12.Data.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id );

            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Director)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Genre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(500);

            builder.HasMany(m => m.Sessions)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
