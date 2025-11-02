using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HW12.Data.Models;

namespace HW12.Data.Configuration
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.RoomName)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(s => s.StartDate)
                .IsRequired();  

            builder.Property(s => s.StartTime)
                .IsRequired()
              .HasColumnType("time");

            builder.Property(s => s.EndTime)
                .IsRequired()
                .HasColumnType("time");


            builder.HasOne(s => s.Movie)
                .WithMany(m => m.Sessions)  
                .HasForeignKey(s => s.MovieId)  
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Sessions", t => t.HasCheckConstraint("CK_Session_EndTime_After_StartTime", "[EndTime] > [StartTime]"));
        }
    }
}
