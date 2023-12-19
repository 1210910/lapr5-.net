using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DDDSample1.Domain.Tasks;

public class VigilanceTaskService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVigilanceTaskRepository _repo;

    public VigilanceTaskService(IUnitOfWork unitOfWork, IVigilanceTaskRepository repo)
    {
        this._unitOfWork = unitOfWork;
        this._repo = repo;
    }
    public async Task<ActionResult<IEnumerable<VigilanceTaskDto>>> GetAllAsync()
    {
        var list = await this._repo.GetAllAsync();
            
        List<VigilanceTaskDto> listDto = list.ConvertAll<VigilanceTaskDto>(cat => new VigilanceTaskDto( cat.Id.AsGuid().ToString(),  
            cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,  cat.RequestName.ToString(), cat.RequestNumber.ToString()));

        return listDto;
    }

    public async Task<ActionResult<VigilanceTaskDto>> GetByIdAsync(TaskId taskId)
    {
        var cat = await this._repo.GetByIdAsync(taskId);
            
        if(cat == null)
            return null;

        return new ActionResult<VigilanceTaskDto>(new VigilanceTaskDto(cat.Id.AsGuid().ToString(),  
            cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,  cat.RequestName.ToString(), cat.RequestNumber.ToString()));
    }

    public async Task<ActionResult<VigilanceTaskDto>> AddAsync(VigilanceTaskDto dto)
    {
        var task = new VigilanceTask( dto.Description, dto.User, 
            dto.RoomDest, dto.RoomOrig, dto.RequestName, 
            dto.RequestNumber);

        await this._repo.AddAsync(task);

        await this._unitOfWork.CommitAsync();

        return new ActionResult<VigilanceTaskDto>(new VigilanceTaskDto(task.Id.AsGuid().ToString(),  
            task.Description,  task.User,  task.RoomDest,  task.RoomOrig,  task.RequestName.ToString(), task.RequestNumber.ToString()));
    }

    public async Task<ActionResult<VigilanceTaskDto>> UpdateAsync(VigilanceTaskDto dto)
    {
        var task = await this._repo.GetByIdAsync(new TaskId(dto.Id)); 

        if (task == null)
            return null;   

        // change all field
        task.ChangeDescription(dto.Description);
            
        await this._unitOfWork.CommitAsync();

        return new ActionResult<VigilanceTaskDto>(new VigilanceTaskDto(task.Id.AsGuid().ToString(),  
            task.Description,  task.User,  task.RoomDest,  task.RoomOrig,  task.RequestName.ToString(), task.RequestNumber.ToString()));
    }
    

    public async Task<ActionResult<VigilanceTaskDto>> DeleteAsync(TaskId taskId)
    {
        var task = await this._repo.GetByIdAsync(taskId);

        if (task == null)
            return null;

        this._repo.Remove(task);

        await this._unitOfWork.CommitAsync();

        return new ActionResult<VigilanceTaskDto>(new VigilanceTaskDto(task.Id.AsGuid().ToString(),  
            task.Description,  task.User,  task.RoomDest,  task.RoomOrig,  task.RequestName.ToString(), task.RequestNumber.ToString()));
    }
}