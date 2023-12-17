using System.Collections.Generic;
using System.Linq;
using DDDSample1.Domain.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Tasks.Repos;

public class TaskRepository
{
    private readonly DDDSample1DbContext _context;
    


    public TaskRepository(DDDSample1DbContext context)
    {
        _context = context;
        
    }

    public Task GetById(string id)
    {
        var taskIdToFind = new TaskId(id); 
        var task = _context.Tasks.FirstOrDefault(t => t.Id == taskIdToFind);
        return task;
    }

    public List<Task> GetAll()
    {
        return _context.Tasks.ToList();
    }

    public Task Add(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return task;
    }

    public Task Update(Task task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
        return task;
    }

    public bool Delete(string id)
    {
        var taskIdToFind = new TaskId(id); 
        var task = _context.Tasks.FirstOrDefault(t => t.Id == taskIdToFind);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}