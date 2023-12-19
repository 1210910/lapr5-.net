using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.persistence;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.TaskRequests.Repos;

public class VigilanceTaskRequestRepository : BaseRepository<VigilanceTaskRequest,TaskRequestId> , IVigilanceTaskRequestRepository
{
    public VigilanceTaskRequestRepository(DbSet<VigilanceTaskRequest> objs) : base(objs)
    {
    }
}