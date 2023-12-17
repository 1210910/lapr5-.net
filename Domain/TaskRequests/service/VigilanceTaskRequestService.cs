using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.dto;
using DDDNetCore.Domain.TaskRequests.persistence;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Domain.TaskRequests.service;

public class VigilanceTaskRequestService
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVigilanceTaskRequestRepository _repo;

    public VigilanceTaskRequestService(IUnitOfWork unitOfWork, IVigilanceTaskRequestRepository repo)
    {
        this._unitOfWork = unitOfWork;
        this._repo = repo;
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
            cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig, cat.RequestName.ToString(),cat.RequestNumber.ToString(), cat.State ));

        return listDto;
        
    }

    public async Task<ActionResult<VigilanceTaskRequestDto>> GetByIdAsync(TaskRequestId taskRequestId)
    {
            
            
            var cat = await this._repo.GetByIdAsync(taskRequestId);
            
            VigilanceTaskRequestDto dto = new VigilanceTaskRequestDto( cat.Id.AsGuid().ToString(),  
                cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig, cat.RequestName.ToString(),cat.RequestNumber.ToString(), cat.State );
            
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
}