using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingLog.Controllers.Resources;
using ProgrammingLog.Models;

namespace ProgrammingLog.Controllers
{
    [Route("/api/tasks")]
    public class TasksController : Controller
    {
        private readonly TaskDbContext dbContext;
        private readonly IMapper mapper;
        public TasksController(TaskDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] ProgrammingTaskResource taskResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = mapper.Map<ProgrammingTaskResource, ProgrammingTask>(taskResource);

            dbContext.Add(task);

            await dbContext.SaveChangesAsync();

            task = await dbContext.Tasks.SingleOrDefaultAsync(t => t.Id == task.Id);

            foreach (var id in taskResource.ProgrammingLanguages)
            {
                task.ProgrammingLanguages.Add(
                    new TaskLanguage
                    {
                        TaskId = task.Id,
                        LanguageId = id
                    });
            }

            await dbContext.SaveChangesAsync();

            task = await dbContext.Tasks
                .Include(pt => pt.ProgrammingLanguages)
                    .ThenInclude(tl => tl.Language)
                .SingleOrDefaultAsync(t => t.Id == task.Id);

            var taskResult = mapper.Map<ProgrammingTask, SaveProgrammingTaskResource>(task);
            return Ok(taskResult);
        }

        [HttpGet]
        public async Task<IEnumerable<SaveProgrammingTaskResource>> GetTasks()
        {
            var tasks = await dbContext.Tasks
                .Include(pt => pt.ProgrammingLanguages)
                    .ThenInclude(tl => tl.Language)
                .ToListAsync();
            return mapper.Map<List<ProgrammingTask>, List<SaveProgrammingTaskResource>>(tasks);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await dbContext.Tasks
                .Include(pt => pt.ProgrammingLanguages)
                    .ThenInclude(tl => tl.Language)
                .SingleOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            dbContext.Tasks.Remove(task);

            await dbContext.SaveChangesAsync();

            return Ok(id);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await dbContext.Tasks
                .Include(pt => pt.ProgrammingLanguages)
                    .ThenInclude(tl => tl.Language)
                .SingleOrDefaultAsync(t => t.Id == id);

            var taskResource = mapper.Map<ProgrammingTask, SaveProgrammingTaskResource>(task);

            return Ok(taskResource);
        }
    }
}