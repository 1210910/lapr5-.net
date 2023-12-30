using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.TaskRequests.dto;
using DDDNetCore.Domain.TaskRequests.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksRequestController : ControllerBase
{
 
    private readonly TaskRequestService _service;

    public TasksRequestController(TaskRequestService service)
    {
        _service = service;
    }

    // GET: api/TasksRequest
    [HttpGet("Pending")]
    public async Task<ActionResult<IEnumerable<TaskRequestOutputDTO>>> GetAllPendingRequests()
    {
        return await _service.GetAllPendingRequestsAsync();
    }
    
    [HttpGet("Accepted")]
    public async Task<ActionResult<IEnumerable<TaskRequestOutputDTO>>> GetAllAcceptedRequests()
    {
        return await _service.GetAllAcceptedRequestsAsync();
    }
}