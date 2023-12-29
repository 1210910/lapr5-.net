using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.dto;
using DDDSample1.Domain.Shared;

namespace DDDNetCore.Domain.TaskRequests.persistence
{

    public interface IDeliveryTaskRequestRepository : IRepository<DeliveryTaskRequest, TaskRequestId>
    {
        Task<List<DeliveryTaskRequest>> GetAllFilteredRequestAsync(string state, string user);

    }

    
}