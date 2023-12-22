
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Tasks;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Tasks.Repos;

public class DeliveryTaskRepository : BaseRepository<DeliveryTask, TaskId>, IDeliveryTaskRepository
{
    public DeliveryTaskRepository(DDDSample1DbContext context) : base(context.DeliveryTasks)
    {
        
    }

    
}