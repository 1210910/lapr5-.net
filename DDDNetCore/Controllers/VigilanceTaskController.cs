using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Tasks;


namespace DDDNetCore.Controllers;

[Route("api/[controller]")]
[ApiController]

public class VigilanceTasksController : ControllerBase
{
    private readonly VigilanceTaskService _service;

        public VigilanceTasksController(VigilanceTaskService service)
        {
            _service = service;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VigilanceTaskDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }
        
        
        [HttpGet("pending")]
        public async Task<ActionResult<List<VigilanceTaskDto>>> GetAllPending()
        {
            return await _service.GetAllPendingAsync();
        }
        
        
        
        
        [HttpPost("start")]
        public async Task<ActionResult<VigilanceTaskDto>> Start(ApproveDto dto)
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
        public async Task<ActionResult<VigilanceTaskDto>> Finish(ApproveDto dto)
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

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VigilanceTaskDto>> GetGetById(Guid id)
        {
            var cat = await _service.GetByIdAsync(new TaskId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        

        
        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<ActionResult<VigilanceTaskDto>> Update(Guid id, VigilanceTaskDto dto)
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
        public async Task<ActionResult<VigilanceTaskDto>> HardDelete(Guid id)
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