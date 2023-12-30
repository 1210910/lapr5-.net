using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.persistence;
using DDDSample1.Domain.Shared;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.TaskRequests.Repos;

public class TaskRequestRepository : BaseRepository<TaskRequest, TaskRequestId>, ITaskRequestRepository
{
    public TaskRequestRepository(DDDSample1DbContext context) : base(context.TaskRequests)
    {
    }

    public async Task<List<TaskRequest>> GetAllPendingRequestAsync()
    {
        return await _objs
            .Where(task => (task is DeliveryTaskRequest || task is VigilanceTaskRequest) && task.State == States.Pending.ToString())
            .ToListAsync();
    }

    public async Task<List<TaskRequest>> GetAllAcceptedRequestAsync()
    {
        return await _objs
            .Where(task => (task is DeliveryTaskRequest || task is VigilanceTaskRequest) && task.State == States.Accepted.ToString())
            .ToListAsync();
    }

   
}