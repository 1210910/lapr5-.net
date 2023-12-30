using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.dto;
using DDDNetCore.Domain.TaskRequests.service;
using Microsoft.AspNetCore.Authorization;


namespace DDDNetCore.Controllers;


[Route("api/[controller]")]
[ApiController]

public class DeliveryTasksRequestController : ControllerBase
{
    private readonly DeliveryTaskRequestService _service;

        public DeliveryTasksRequestController(DeliveryTaskRequestService service)
        {
            _service = service;
        }

        // GET: api/TasksRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryTaskRequestDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }
        
        [HttpGet("pending")]
        public async Task<ActionResult<List<DeliveryTaskRequestDto>>> GetPending()
        {
            return await _service.GetAllPendingAsync();
        }

        // GET: api/TasksRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryTaskRequestDto>> GetGetById(Guid id)
        {
            var cat = await _service.GetByIdAsync(new TaskRequestId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        // POST: api/TasksRequest
        [HttpPost]
        public async Task<ActionResult<DeliveryTaskRequestDto>> Create(DeliveryTaskRequestDto dto)
        {
            var cat = await _service.AddAsync(dto);

            return Ok(cat.Value);
        }
        
        [HttpPost("approve")]
        public async Task<ActionResult<DeliveryTaskRequestDto>> Approve(ApproveDto dto )
        {
            try
            {
                var cat = await _service.ApproveAsync(dto);
                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(cat.Value);
            }
            catch(Exception ex)
            {
                return BadRequest(new {Message = ex});
            }
        }
        
        [HttpPost("reject")]
        public async Task<ActionResult<DeliveryTaskRequestDto>> Reject(ApproveDto dto)
        {
            var cat = await _service.RejectAsync(dto);

            return Ok(cat.Value);
        }

        
        // PUT: api/TasksRequest/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryTaskRequestDto>> Update(Guid id, DeliveryTaskRequestDto dto)
        {
            if (id != new Guid(dto.Id))
            {
                return BadRequest();
            }

            try
            {
                var cat = await _service.UpdateAsync(dto);
                
                if (cat == null)
                {
                    return NotFound();
                }
                return Ok(cat);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }
        
        [HttpGet("state")]
        public async Task<ActionResult<DeliveryTaskRequestDto>> GetByState([FromQuery] string state)
        {
            throw new NotImplementedException();
        }
        
        
        // DELETE: api/TasksRequest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliveryTaskRequestDto>> HardDelete(Guid id)
        {
            try
            {
                var cat = await _service.DeleteAsync(new TaskRequestId(id));

                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(cat);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
        
        // GET: api/deliverytasksRequest/filtered
        [HttpGet("filtered")]
        public async Task<List<DeliveryTaskRequestDto>> GetAllFiltered()
        {
            HttpContext.Request.Query.TryGetValue("state", out var stateValues);
            if (stateValues.Equals("undefined")|| stateValues.Equals("All"))
            {
                stateValues = string.Empty;
            }

            HttpContext.Request.Query.TryGetValue("user", out var userValues);
            if (userValues.Equals("undefined"))
            {
                userValues = string.Empty;
            }

            return await _service.GetAllFilteredRequestAsync(stateValues, userValues);
        }
}