using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.dto;
using DDDNetCore.Domain.TaskRequests.persistence;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DDDNetCore.Domain.TaskRequests.service{

public class DeliveryTaskRequestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDeliveryTaskRequestRepository _repo;
    private readonly DeliveryTaskService _taskService;

    public DeliveryTaskRequestService(IUnitOfWork unitOfWork, IDeliveryTaskRequestRepository repo, DeliveryTaskService taskService)
    {
        this._unitOfWork = unitOfWork;
        this._repo = repo;
        this._taskService = taskService ;
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
    
    
    public async Task<ActionResult<DeliveryTaskDto>> ApproveAsync(ApproveDto dto)
    {
        try
        {
            var cat = await this._repo.GetByIdAsync(new TaskRequestId(dto.Id));
            if (cat == null)
            {
                return null;
            }

            if (cat.DestName.ToString() == "")
            {
                Console.WriteLine("DestName is null");
                return null;
            }
            
            Console.WriteLine(JsonConvert.SerializeObject(cat));

            //add update logic here
            cat.aproveRequest();
            await this._repo.UpdateAsync(cat);
            await this._unitOfWork.CommitAsync();


            var task = new DeliveryTaskDto(cat.Id.Value, cat.Description, cat.User, cat.RoomDest, cat.RoomOrig,
                cat.DestName.Value, cat.OrigName.Value, cat.DestPhoneNumber.ToString(), cat.OrigPhoneNumber.ToString(), cat.ConfirmationCode.Value, dto.RobotId, "");
            
            return await this._taskService.AddAsync(task);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<ActionResult<DeliveryTaskRequestDto>> RejectAsync(ApproveDto dtos)
    {
        try
        {
            var cat = await this._repo.GetByIdAsync(new TaskRequestId(dtos.Id));
            
            if (cat == null)
            {
                System.Console.WriteLine("cat is null");
                return null;
            }
        
            //add update logic here
            cat.rejectRequest();
            await this._repo.UpdateAsync(cat);
            await this._unitOfWork.CommitAsync();
        
            DeliveryTaskRequestDto dto = new DeliveryTaskRequestDto( cat.Id.AsGuid().ToString(),  
                cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,  cat.DestName.ToString(),cat.OrigName.ToString(),cat.DestPhoneNumber.ToString(),  cat.OrigPhoneNumber.ToString(), 
                cat.State,cat.ConfirmationCode.Value);
     
            
            return dto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;

        }
        
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

    public async Task<ActionResult<List<DeliveryTaskRequestDto>>> GetAllPendingAsync()
    {
            var list = await this._repo.GetAllAsync();

            list.RemoveAll(x => x.State == States.Rejected.ToString() || x.State == States.Rejected.ToString());
            
            List<DeliveryTaskRequestDto> listDto = list.ConvertAll<DeliveryTaskRequestDto>(cat => new DeliveryTaskRequestDto( cat.Id.AsGuid().ToString(),  
                cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,  cat.DestName.ToString(),cat.OrigName.ToString(),cat.DestPhoneNumber.ToString(),  cat.OrigPhoneNumber.ToString(), 
                cat.State,cat.ConfirmationCode.Value));
            
            return listDto;
    }
}
}