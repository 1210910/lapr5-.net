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
            builder.HasKey(vt => vt.Id);
            builder.Property(vt => vt.Id).HasColumnName("Id").IsRequired();

            // Configuração das propriedades PhoneNumber e Name
            builder.Property(vt => vt.RequestNumber.ToString()).HasColumnName("RequestNumber").IsRequired();
            builder.Property(vt => vt.RequestName.ToString()).HasColumnName("RequestName").IsRequired();

            // Mapeamento das propriedades herdadas de Task
            builder.Property(vt => vt.Description).HasColumnName("Description").IsRequired();
            builder.Property(vt => vt.User).HasColumnName("User").IsRequired();
            builder.Property(vt => vt.RoomDest).HasColumnName("RoomDest").IsRequired();
            builder.Property(vt => vt.RoomOrig).HasColumnName("RoomOrig").IsRequired();
            

        }
    }
