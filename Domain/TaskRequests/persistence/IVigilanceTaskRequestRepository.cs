using System.Collections.Generic;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDSample1.Domain.Shared;

namespace DDDNetCore.Domain.TaskRequests.persistence{

public interface IVigilanceTaskRequestRepository: IRepository<VigilanceTaskRequest, TaskRequestId>
{
   
}
}