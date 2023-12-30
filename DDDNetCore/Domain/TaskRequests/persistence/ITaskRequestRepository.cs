using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.TaskRequests.domain;

namespace DDDNetCore.Domain.TaskRequests.persistence{

public interface ITaskRequestRepository
{
    Task<List<TaskRequest>> GetAllPendingRequestAsync();
    Task<List<TaskRequest>> GetAllAcceptedRequestAsync();
}
}