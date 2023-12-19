using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.persistence;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.TaskRequests.Repos;

public class DeliveryTaskRequestRepository : BaseRepository<DeliveryTaskRequest, TaskRequestId>, IDeliveryTaskRequestRepository
{

  

    public DeliveryTaskRequestRepository(DDDSample1DbContext context) : base(context.DeliveryTaskRequests)
    {
       
    }

    

}