using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.dto;
using DDDNetCore.Domain.TaskRequests.persistence;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task = DDDSample1.Domain.Tasks.Task;

namespace DDDNetCore.Domain.TaskRequests.service;

public class VigilanceTaskRequestService
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVigilanceTaskRequestRepository _repo;
    private readonly VigilanceTaskService _service;

    public VigilanceTaskRequestService(IUnitOfWork unitOfWork, IVigilanceTaskRequestRepository repo,VigilanceTaskService service)
    {
        this._unitOfWork = unitOfWork;
        this._repo = repo;
        this._service = service;
    }
    
    public async Task<ActionResult<VigilanceTaskDto>> ApproveAsync(ApproveDto dto)
    {
        var task = await this._repo.GetByIdAsync(new TaskRequestId(dto.Id));
        if (task == null)
        {
            return null;
        }
        
        task.approve();
        await this._repo.UpdateAsync(task);
        await this._unitOfWork.CommitAsync();
        
        VigilanceTask cat = new VigilanceTask(task.Description, task.User, task.RoomDest, task.RoomOrig, task.RequestName.Value, task.RequestNumber.Value,task.Id.AsGuid().ToString(),dto.RobotId);
        
        await this._service.AddAsync(cat);
        
        return new ActionResult<VigilanceTaskDto>(new VigilanceTaskDto(cat.Id.AsGuid().ToString(),  
            cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,  cat.RequestName.ToString(), cat.RequestNumber.ToString(),cat.RobotId.ToString(),cat.Status.ToString()));
    }
    
    public async Task<ActionResult<VigilanceTaskRequestDto>> RejectAsync(ApproveDto dto)
    {
        var task = await this._repo.GetByIdAsync(new TaskRequestId(dto.Id));
        if (task == null)
        {
            return null;
        }
        
        task.reject();
        await this._repo.UpdateAsync(task);
        
        await this._unitOfWork.CommitAsync();
        return new ActionResult<VigilanceTaskRequestDto>(new VigilanceTaskRequestDto(task.Id.AsGuid().ToString(),  
            task.Description,  task.User,  task.RoomDest, task.RoomOrig,
            task.RequestName.ToString(),task.RequestNumber.ToString(), task.State ));
    }
   
    
    public async Task<ActionResult<IEnumerable<VigilanceTaskRequestDto>>> UpdateAsync(VigilanceTaskRequestDto dto)
    {
            
            var cat = await this._repo.GetByIdAsync(new TaskRequestId(dto.Id));
            if (cat == null)
            {
                return null;
            }
            
            //add update logic here
            
            await this._unitOfWork.CommitAsync();
            return null;
    }

    public async Task<ActionResult<IEnumerable<VigilanceTaskRequestDto>>> GetAllAsync()
    {
        
        var list = await this._repo.GetAllAsync();
        
        List<VigilanceTaskRequestDto> listDto = list.ConvertAll<VigilanceTaskRequestDto>(cat => new VigilanceTaskRequestDto( cat.Id.AsGuid().ToString(),  
            cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig, 
            cat.RequestName.ToString(),cat.RequestNumber.ToString(), cat.State));

        return listDto;
        
    }

    public async Task<ActionResult<VigilanceTaskRequestDto>> GetByIdAsync(TaskRequestId taskRequestId)
    {
            
            
            var cat = await this._repo.GetByIdAsync(taskRequestId);
            
            VigilanceTaskRequestDto dto = new VigilanceTaskRequestDto( cat.Id.AsGuid().ToString(),  
                cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig, 
                cat.RequestName.ToString(),cat.RequestNumber.ToString(), cat.State );
            
            return dto;
    }

    public async Task<ActionResult<VigilanceTaskRequestDto>> AddAsync(VigilanceTaskRequestDto dto)
    {
       
        
        VigilanceTaskRequest cat = new VigilanceTaskRequest(dto.Description, dto.User, dto.RoomDest, dto.RoomOrig, dto.RequestName, dto.RequestNumber);
        
        await this._repo.AddAsync(cat);
        await this._unitOfWork.CommitAsync();
        
        return dto;
        
        
    }

  

    public async Task<ActionResult<VigilanceTaskRequestDto>> DeleteAsync(TaskRequestId taskRequestId)
    {
        var cat = await this._repo.GetByIdAsync(taskRequestId);
        if (cat == null)
        {
            return null;
        }
        
        this._repo.Remove(cat);
        await this._unitOfWork.CommitAsync();
        return null;
    }


    public async Task<ActionResult<List<VigilanceTaskRequestDto>>> GetAllPendingAsync()
    {
        var list = await this._repo.GetAllAsync();
        
        list.RemoveAll(x => x.State != States.Pending.ToString());
        
        List<VigilanceTaskRequestDto> listDto = list.ConvertAll<VigilanceTaskRequestDto>(cat => new VigilanceTaskRequestDto( cat.Id.AsGuid().ToString(),  
            cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,
            cat.RequestName.ToString(),cat.RequestNumber.ToString(), cat.State));

        return listDto;
    }
    public async Task<List<VigilanceTaskRequestDto>> GetAllFilteredRequestAsync(string state, string user)
    {
        var list = await this._repo.GetAllFilteredRequestAsync(state, user);

        List<VigilanceTaskRequestDto> listDto = list.ConvertAll<VigilanceTaskRequestDto>(cat => new VigilanceTaskRequestDto( cat.Id.AsGuid().ToString(),  
            cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,
            cat.RequestName.ToString(),cat.RequestNumber.ToString(), cat.State));
        
        return listDto;
    }
}