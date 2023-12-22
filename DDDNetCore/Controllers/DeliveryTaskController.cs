
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DDDNetCore.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DeliveryTasksController : ControllerBase
{
    private readonly DeliveryTaskService _service;
    
        public DeliveryTasksController(DeliveryTaskService service)
        {
            _service = service;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<List<DeliveryTaskDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryTaskDto>> GetGetById(Guid id)
        {
            var cat = await _service.GetByIdAsync(new TaskId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        [HttpGet("pending")]
        public async Task<ActionResult<List<DeliveryTaskDto>>> GetPending()
        {
            return await _service.GetAllPendingAsync();
        }

        // POST: api/Tasks
        [HttpPost("start")]
        public async Task<ActionResult<DeliveryTaskDto>> Start(ApproveDto dto)
        {
            try
            {
                var task = await _service.StartAsync(dto);

                return Ok(task.Value);
            }
            catch(Exception ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        [HttpPost("finish")]
        public async Task<ActionResult<DeliveryTaskDto>> Finish(ApproveDto dto)
        {
            try
            {
            var task = await _service.CompleteAsync(dto);

            return Ok(task.Value);
            }
            catch(Exception ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }
        
        [HttpGet("robot")]
        public async Task<ActionResult<List<DeliveryTaskDto>>> GetByRobotId(Guid id)
        {
            throw new NotImplementedException();
        }
        
       
        
        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryTaskDto>> Update(Guid id, DeliveryTaskDto dto)
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
        
        
        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliveryTaskDto>> HardDelete(Guid id)
        {
            try
            {
                var cat = await _service.DeleteAsync(new TaskId(id));

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
}
    