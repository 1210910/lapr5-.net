using System.Collections.Generic;
using System.Linq;
using DDDSample1.Domain.Tasks;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Tasks.Repos;

public class VigilanceTaskRepository : BaseRepository<VigilanceTask,TaskId> , IVigilanceTaskRepository
{
    public VigilanceTaskRepository(DbSet<VigilanceTask> objs) : base(objs)
    {
    }
}