using System.Collections.Generic;

namespace DDDSample1.Domain.Tasks
{
    public interface ITaskRepository
    {
        Task GetById(int id);
        List<Task> GetAll();
        Task Add(Task task);
        Task Update(Task task);
        bool Delete(int id);
    }
}