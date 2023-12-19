using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.dto;
using DDDNetCore.Domain.TaskRequests.persistence;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Domain.TaskRequests.service{

public class DeliveryTaskRequestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDeliveryTaskRequestRepository _repo;

    public DeliveryTaskRequestService(IUnitOfWork unitOfWork, IDeliveryTaskRequestRepository repo)
    {
        this._unitOfWork = unitOfWork;
        this._repo = repo;
    }
    public async Task<ActionResult<IEnumerable<DeliveryTaskRequestDto>>> UpdateAsync(DeliveryTaskRequestDto dto)
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

    public async Task<ActionResult<IEnumerable<DeliveryTaskRequestDto>>> GetAllAsync()
    {
        
        var list = await this._repo.GetAllAsync();
        
        List<DeliveryTaskRequestDto> listDto = list.ConvertAll<DeliveryTaskRequestDto>(cat => new DeliveryTaskRequestDto( cat.Id.AsGuid().ToString(),  
            cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,  cat.DestName.ToString(),cat.OrigName.ToString(),cat.DestPhoneNumber.ToString(),  cat.OrigPhoneNumber.ToString(), 
             cat.State,cat.ConfirmationCode.Value));

        return listDto;
        
        
    }

    public async Task<ActionResult<DeliveryTaskRequestDto>> GetByIdAsync(TaskRequestId taskRequestId)
    {
        
        
        var cat = await this._repo.GetByIdAsync(taskRequestId);
        
        DeliveryTaskRequestDto dto = new DeliveryTaskRequestDto( cat.Id.AsGuid().ToString(),  
            cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,  cat.DestName.ToString(),cat.OrigName.ToString(),cat.DestPhoneNumber.ToString(),  cat.OrigPhoneNumber.ToString(), 
             cat.State,cat.ConfirmationCode.Value);

        return dto;
        
        
    }

    public async Task<ActionResult<DeliveryTaskRequestDto>> AddAsync(DeliveryTaskRequestDto dto)
    {
        var cat = new DeliveryTaskRequest(dto.Description, dto.User, dto.RoomDest, dto.RoomOrig, dto.DestName, dto.OrigName, 
            dto.DestPhoneNumber, dto.OrigPhoneNumber, dto.Code);
        
        System.Console.WriteLine("DeliveryTaskRequestService");
        System.Console.WriteLine(cat.Id);
        // write a line to the console
        if (cat.Id == null)
        {
            return null;
        }
        await this._repo.AddAsync(cat);
        await this._unitOfWork.CommitAsync();
        return dto;
    }

   

    public async Task<ActionResult<DeliveryTaskRequestDto>> DeleteAsync(TaskRequestId taskRequestId)
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
}