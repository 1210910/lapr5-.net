using DDDNetCore.Domain.TaskRequests.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infrastructure.TaskRequests;

internal class DeliveryTaskRequestEntityTypeConfiguration : IEntityTypeConfiguration<DeliveryTaskRequest>
{
    public void Configure(EntityTypeBuilder<DeliveryTaskRequest> builder)
    {
        builder.ToTable("DeliveryTasks");

        // Configuração da chave primária
        builder.HasKey(dt => dt.Id);
        builder.Property(dt => dt.Id).HasColumnName("Id").IsRequired();

        // Configurações específicas da DeliveryTask
        builder.Property(dt => dt.DestPhoneNumber.ToString()).HasColumnName("DestPhoneNumber").IsRequired();
        builder.Property(dt => dt.OrigPhoneNumber.ToString()).HasColumnName("OrigPhoneNumber").IsRequired();

        // Configuração para mapear ConfirmationCode como uma string no banco de dados
        builder.Property(dt => dt.ConfirmationCode.Value).HasColumnName("ConfirmationCode").IsRequired();
        
        builder.Property(dt => dt.State.ToString()).HasColumnName("State").IsRequired();

        
        builder.Property(dt => dt.DestName.ToString()).HasColumnName("DestName").IsRequired();
        builder.Property(dt => dt.OrigName.ToString()).HasColumnName("OrigName").IsRequired();

        // Mapeamento das propriedades herdadas de Task
        builder.Property(dt => dt.Description).HasColumnName("Description").IsRequired();
        builder.Property(dt => dt.User).HasColumnName("User").IsRequired();
        builder.Property(dt => dt.RoomDest).HasColumnName("RoomDest").IsRequired();
        builder.Property(dt => dt.RoomOrig).HasColumnName("RoomOrig").IsRequired();
        

    }
}