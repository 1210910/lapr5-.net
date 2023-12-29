using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.persistence;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.TaskRequests.Repos;

public class VigilanceTaskRequestRepository : BaseRepository<VigilanceTaskRequest,TaskRequestId> , IVigilanceTaskRequestRepository
{
    public VigilanceTaskRequestRepository(DDDSample1DbContext context) : base(context.VigilanceTaskRequests)
    {
    }
    
    public async Task<List<VigilanceTaskRequest>> GetAllFilteredRequestAsync(string state, string user)
    {
        var query = _objs.AsQueryable();

        if (!string.IsNullOrEmpty(state))
        {
            query = query.Where(t => t.State == state);
        }

        if (!string.IsNullOrEmpty(user))
        {
            query = query.Where(t => t.User == user);
        }

        var filteredTasks = await query.ToListAsync();

        return filteredTasks;
    }
}