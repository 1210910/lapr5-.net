using DDDNetCore.Domain.TaskRequests.domain;
using DDDSample1.Domain.Tasks;
using DDDSample1.Infrastructure.TaskRequests;
using DDDSample1.Infrastructure.Tasks;
using Microsoft.EntityFrameworkCore;



namespace DDDSample1.Infrastructure
{
    public class DDDSample1DbContext : DbContext
    {
        public DbSet<VigilanceTask> VigilanceTasks { get; set; }

        public DbSet<DeliveryTask> DeliveryTasks { get; set; }

        public DbSet<Task> Tasks { get; set; }
        
        public DbSet<VigilanceTaskRequest> VigilanceTaskRequests { get; set; }
        
        public DbSet<DeliveryTaskRequest> DeliveryTaskRequests { get; set; }
        
        public DbSet<TaskRequest> TaskRequests { get; set; }
        

     

        public DDDSample1DbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VigilanceTaskEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryTaskEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TaskRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VigilanceTaskRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryTaskRequestEntityTypeConfiguration());
        }
       
    }
}