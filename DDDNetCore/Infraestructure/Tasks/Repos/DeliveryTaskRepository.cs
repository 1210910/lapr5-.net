
using DDDSample1.Domain.Tasks;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Tasks.Repos;

public class DeliveryTaskRepository : BaseRepository<DeliveryTask, TaskId>, IDeliveryTaskRepository
{
    public DeliveryTaskRepository(DbSet<DeliveryTask> objs) : base(objs)
    {
    }
}