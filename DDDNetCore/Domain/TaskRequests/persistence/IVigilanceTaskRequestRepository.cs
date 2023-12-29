using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDSample1.Domain.Shared;

namespace DDDNetCore.Domain.TaskRequests.persistence{

public interface IVigilanceTaskRequestRepository: IRepository<VigilanceTaskRequest, TaskRequestId>
{
    Task<List<VigilanceTaskRequest>> GetAllFilteredRequestAsync(string state, string user);
}
}