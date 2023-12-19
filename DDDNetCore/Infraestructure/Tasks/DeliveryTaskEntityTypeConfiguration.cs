using DDDSample1.Domain.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infrastructure.Tasks;

internal class DeliveryTaskEntityTypeConfiguration : IEntityTypeConfiguration<DeliveryTask>
{
    public void Configure(EntityTypeBuilder<DeliveryTask> builder)
    {
        builder.ToTable("DeliveryTasks");

        // Configuração da chave primária
        builder.HasBaseType<Task>();
        builder.Property(dt => dt.Id).HasColumnName("Id").IsRequired();

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

        // Mapeamento das propriedades herdadas de Task
        builder.Property(dt => dt.Description).HasColumnName("Description").IsRequired();
        builder.Property(dt => dt.User).HasColumnName("User").IsRequired();
        builder.Property(dt => dt.RoomDest).HasColumnName("RoomDest").IsRequired();
        builder.Property(dt => dt.RoomOrig).HasColumnName("RoomOrig").IsRequired();
        

    }
}