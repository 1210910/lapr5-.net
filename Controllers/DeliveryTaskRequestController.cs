using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDNetCore.Domain.TaskRequests.dto;
using DDDNetCore.Domain.TaskRequests.service;


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

            return CreatedAtAction(nameof(GetGetById), new { id = cat.Value.Id }, cat);
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
}