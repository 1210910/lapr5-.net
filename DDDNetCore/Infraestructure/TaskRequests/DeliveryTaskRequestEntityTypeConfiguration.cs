using DDDNetCore.Domain.TaskRequests.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infrastructure.TaskRequests;

internal class DeliveryTaskRequestEntityTypeConfiguration : IEntityTypeConfiguration<DeliveryTaskRequest>
{
    public void Configure(EntityTypeBuilder<DeliveryTaskRequest> builder)
    {
        builder.ToTable("DeliveryTasksRequests");

        // Configuração da chave primária
        builder.HasBaseType<TaskRequest>();

        builder.Property(dt => dt.Id).HasColumnName("Id").IsRequired();
        
        

        builder.Property(t => t.State).HasColumnName("State").IsRequired();
        builder.Property(t => t.Description).HasColumnName("Description").IsRequired();
        builder.Property(t => t.User).HasColumnName("User").IsRequired();
        builder.Property(t => t.RoomOrig).HasColumnName("RoomOrig").IsRequired();
        builder.Property(t => t.RoomDest).HasColumnName("RoomDest").IsRequired();
       
        // Configurações específicas da DeliveryTask
        builder.OwnsOne(dt => dt.DestPhoneNumber, destPhone =>
        {
            destPhone.Property(dp => dp.Value).HasColumnName("DestPhoneNumber").IsRequired();
        });

        builder.OwnsOne(dt => dt.OrigPhoneNumber, origPhone =>
        {
            origPhone.Property(op => op.Value).HasColumnName("OrigPhoneNumber").IsRequired();
        });

        builder.OwnsOne(dt => dt.ConfirmationCode, code =>
        {
            code.Property(c => c.Value).HasColumnName("ConfirmationCode").IsRequired();
        });

        builder.OwnsOne(dt => dt.DestName, destName =>
        {
            destName.Property(dn => dn.Value).HasColumnName("DestName").IsRequired();
        });

        builder.OwnsOne(dt => dt.OrigName, origName =>
        {
            origName.Property(on => on.Value).HasColumnName("OrigName").IsRequired();
        });
        
    
        
        

    }
}