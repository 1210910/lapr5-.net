using DDDNetCore.Domain.TaskRequests.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infrastructure.TaskRequests;

internal class VigilanceTaskRequestEntityTypeConfiguration : IEntityTypeConfiguration<VigilanceTaskRequest>
{
    public void Configure(EntityTypeBuilder<VigilanceTaskRequest> builder)
    {
        builder.ToTable("VigilanceTasksRequests");

        // Configuração da chave primária
        builder.HasBaseType<TaskRequest>();
        builder.Property(vt => vt.Id).HasColumnName("Id").IsRequired();
        
        builder.Property(vt => vt.State).HasColumnName("State").IsRequired();

        // Configuração das propriedades PhoneNumber e Name
        builder.OwnsOne(vt => vt.RequestName, destPhone =>
        {
            destPhone.Property(dp => dp.Value).HasColumnName("RequestName").IsRequired();
        });
        
        builder.OwnsOne(vt => vt.RequestNumber, destPhone =>
        {
            destPhone.Property(dp => dp.Value).HasColumnName("RequestNumber").IsRequired();
        });

        // Mapeamento das propriedades herdadas de Task
        builder.Property(vt => vt.Description).HasColumnName("Description").IsRequired();
        builder.Property(vt => vt.User).HasColumnName("User").IsRequired();
        builder.Property(vt => vt.RoomDest).HasColumnName("RoomDest").IsRequired();
        builder.Property(vt => vt.RoomOrig).HasColumnName("RoomOrig").IsRequired();
            

    }
}