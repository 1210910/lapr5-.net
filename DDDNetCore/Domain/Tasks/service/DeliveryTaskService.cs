using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Tasks.mappers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DDDSample1.Domain.Tasks
{
    public class DeliveryTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDeliveryTaskRepository _repo;

        public DeliveryTaskService(IUnitOfWork unitOfWork, IDeliveryTaskRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }
        public async Task<ActionResult<List<DeliveryTaskDto>>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<DeliveryTaskDto> listDto = list.ConvertAll<DeliveryTaskDto>(cat => new DeliveryTaskDto( cat.Id.AsGuid().ToString(),  
                cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,  cat.DestName.ToString(),cat.OrigName.ToString(),cat.DestPhoneNumber.ToString(),  cat.OrigPhoneNumber.ToString(), 
                 cat.ConfirmationCode.Value));

            return listDto;
            
        }

        public async Task<ActionResult<DeliveryTaskDto>> GetByIdAsync(TaskId taskId)
        {
            var cat = await this._repo.GetByIdAsync(taskId);
            
            if(cat == null)
                return null;

            return new ActionResult<DeliveryTaskDto>(new DeliveryTaskDto(cat.Id.AsGuid().ToString(),  
                cat.Description,  cat.User,  cat.RoomDest,  cat.RoomOrig,  cat.DestName.ToString(),cat.OrigName.ToString(),cat.DestPhoneNumber.ToString(),  cat.OrigPhoneNumber.ToString(), 
                 cat.ConfirmationCode.Value));
        }

        public async Task<ActionResult<DeliveryTaskDto>> AddAsync(DeliveryTaskDto dto)
        {
            var task = new DeliveryTask( dto.Description, dto.User, 
                dto.RoomDest, dto.RoomOrig, dto.DestName, 
                dto.OrigName, dto.DestPhoneNumber, dto.OrigPhoneNumber, 
                dto.Code);

            await this._repo.AddAsync(task);

            await this._unitOfWork.CommitAsync();

            return new ActionResult<DeliveryTaskDto>(new DeliveryTaskDto(task.Id.AsGuid().ToString(),  
                task.Description,  task.User,  task.RoomDest,  task.RoomOrig,  task.DestName.ToString(),task.OrigName.ToString(),task.DestPhoneNumber.ToString(),  task.OrigPhoneNumber.ToString(), 
                 task.ConfirmationCode.Value));
        }

        public async Task<ActionResult<DeliveryTaskDto>> UpdateAsync(DeliveryTaskDto dto)
        {
            var task = await this._repo.GetByIdAsync(new TaskId(dto.Id)); 

            if (task == null)
                return null;   

            // change all field
            task.ChangeDescription(dto.Description);
            
            await this._unitOfWork.CommitAsync();

            return new ActionResult<DeliveryTaskDto>(new DeliveryTaskDto(task.Id.AsGuid().ToString(),  
                task.Description,  task.User,  task.RoomDest,  task.RoomOrig,  task.DestName.ToString(),task.OrigName.ToString(),task.DestPhoneNumber.ToString(),  task.OrigPhoneNumber.ToString(), 
                 task.ConfirmationCode.Value));
        }

        

        public async Task<ActionResult<DeliveryTaskDto>> DeleteAsync(TaskId taskId)
        {
            var category = await this._repo.GetByIdAsync(taskId); 

            if (category == null)
                return null;   
            
            
            this._repo.Remove(category);
            await this._unitOfWork.CommitAsync();

            return new ActionResult<DeliveryTaskDto>(new DeliveryTaskDto(category.Id.AsGuid().ToString(),  
                category.Description,  category.User,  category.RoomDest,  category.RoomOrig,  category.DestName.ToString(),category.OrigName.ToString(),category.DestPhoneNumber.ToString(),  category.OrigPhoneNumber.ToString(), 
                category.ConfirmationCode.Value));;
        }
    }
}