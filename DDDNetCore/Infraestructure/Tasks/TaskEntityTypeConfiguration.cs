using DDDSample1.Domain.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infrastructure.Tasks;

internal class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();

        builder.Property(t => t.Description).HasColumnName("Description").IsRequired();
        builder.Property(t => t.User).HasColumnName("User").IsRequired();
        builder.Property(t => t.RoomOrig).HasColumnName("RoomOrig").IsRequired();
        builder.Property(t => t.RoomDest).HasColumnName("RoomDest").IsRequired();
        builder.Property(t => t.Status).HasColumnName("Status").IsRequired();
        builder.Property(t => t.RobotId).HasColumnName("RobotId").IsRequired();
       
    }
}