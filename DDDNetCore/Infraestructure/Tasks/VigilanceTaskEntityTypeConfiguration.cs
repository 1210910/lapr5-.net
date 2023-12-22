using DDDSample1.Domain.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infrastructure.Tasks;


    internal class VigilanceTaskEntityTypeConfiguration : IEntityTypeConfiguration<VigilanceTask>
    {
        public void Configure(EntityTypeBuilder<VigilanceTask> builder)
        {
            builder.ToTable("VigilanceTasks");

            // Configuração da chave primária
            builder.HasBaseType<Task>();
            
            builder.Property(vt => vt.Id).HasColumnName("Id").IsRequired();
            
            builder.Property(dt => dt.Id).HasColumnName("Id").IsRequired();
        
            
            builder.Property(t => t.Description).HasColumnName("Description").IsRequired();
            builder.Property(t => t.User).HasColumnName("User").IsRequired();
            builder.Property(t => t.RoomOrig).HasColumnName("RoomOrig").IsRequired();
            builder.Property(t => t.RoomDest).HasColumnName("RoomDest").IsRequired();
            builder.Property(t => t.Status).HasColumnName("Status").IsRequired();
            builder.Property(t => t.RobotId).HasColumnName("RobotId").IsRequired();

            // Configuração das propriedades PhoneNumber e Name
            builder.OwnsOne(vt => vt.RequestName, destPhone =>
            {
                destPhone.Property(dp => dp.Value).HasColumnName("RequestName").IsRequired();
            });
          
            builder.OwnsOne(vt => vt.RequestNumber, destPhone =>
            {
                destPhone.Property(dp => dp.Value).HasColumnName("RequestNumber").IsRequired();
            });

          
            

        }
    }
