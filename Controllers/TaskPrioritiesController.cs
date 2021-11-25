using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCore_WebApi.Data;
using EFCore_WebApi.Models;

namespace EFCore_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskPrioritiesController : ControllerBase
    {
        private readonly TodoContext _context;

        public TaskPrioritiesController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TaskPriorities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskPriority>>> GetTaskPriorities()
        {
            return await _context.TaskPriorities.ToListAsync();
        }

        // GET: api/TaskPriorities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskPriority>> GetTaskPriority(long id)
        {
            var taskPriority = await _context.TaskPriorities.FindAsync(id);

            if (taskPriority == null)
            {
                return NotFound();
            }

            return taskPriority;
        }

        // PUT: api/TaskPriorities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskPriority(long id, TaskPriority taskPriority)
        {
            if (id != taskPriority.TaskPriorityId)
            {
                return BadRequest();
            }

            _context.Entry(taskPriority).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskPriorityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaskPriorities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskPriority>> PostTaskPriority(TaskPriority taskPriority)
        {
            _context.TaskPriorities.Add(taskPriority);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskPriority", new { id = taskPriority.TaskPriorityId }, taskPriority);
        }

        // DELETE: api/TaskPriorities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskPriority(long id)
        {
            var taskPriority = await _context.TaskPriorities.FindAsync(id);
            if (taskPriority == null)
            {
                return NotFound();
            }

            _context.TaskPriorities.Remove(taskPriority);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskPriorityExists(long id)
        {
            return _context.TaskPriorities.Any(e => e.TaskPriorityId == id);
        }
    }
}
