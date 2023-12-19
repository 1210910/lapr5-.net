
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Tasks;

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

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<DeliveryTaskDto>> Create(DeliveryTaskDto dto)
        {
            var task = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = task.Value.Id }, task);
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
    