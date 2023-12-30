using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.dto;
using DDDNetCore.Domain.TaskRequests.persistence;
using DDDSample1.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Domain.TaskRequests.service;

public class TaskRequestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITaskRequestRepository _repo;
    private readonly IMapper _mapper;
    
    public TaskRequestService(IUnitOfWork unitOfWork, ITaskRequestRepository repo, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._repo = repo;
        this._mapper = mapper;
       
    }
    
    public async Task<ActionResult<IEnumerable<TaskRequestOutputDTO>>> GetAllPendingRequestsAsync()
    {
        
        List<TaskRequest> list = await this._repo.GetAllPendingRequestAsync();
        
        var taskDtos = _mapper.Map<List<TaskRequestOutputDTO>>(list);
        
        return taskDtos;
        
        
    }
    public async Task<ActionResult<IEnumerable<TaskRequestOutputDTO>>> GetAllAcceptedRequestsAsync()
    {
        
        var list = await this._repo.GetAllAcceptedRequestAsync();
       
        var taskDtos = _mapper.Map<List<TaskRequestOutputDTO>>(list);

        return taskDtos;
        
        
    }
}