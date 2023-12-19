using System.Collections.Generic;
using DDDNetCore.Domain.TaskRequests.domain;

namespace DDDNetCore.Domain.TaskRequests.persistence{

public interface ITaskRequestRepository
{
    TaskRequest GetById(int id);
    List<TaskRequest> GetAll();
    TaskRequest Add(TaskRequest task);
    TaskRequest Update(TaskRequest task);
    bool Delete(int id);
}
}