using Microsoft.EntityFrameworkCore;
using DDDNetCore.Domain.TaskRequests.domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infrastructure.TaskRequests;

internal class TaskRequestEntityTypeConfiguration : IEntityTypeConfiguration<TaskRequest>
{
    public void Configure(EntityTypeBuilder<TaskRequest> builder)
    {
        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        
        builder.Property(t => t.State).HasColumnName("State").IsRequired();
        builder.Property(t => t.Description).HasColumnName("Description").IsRequired();
        builder.Property(t => t.User).HasColumnName("User").IsRequired();
        builder.Property(t => t.RoomOrig).HasColumnName("RoomOrig").IsRequired();
        builder.Property(t => t.RoomDest).HasColumnName("RoomDest").IsRequired();
       
    }
}