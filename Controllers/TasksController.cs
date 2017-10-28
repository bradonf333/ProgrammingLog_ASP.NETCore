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

            // works!!!!
            foreach (var item in taskResource.ProgrammingLanguages)
            {
                Console.WriteLine("Language Id from body: " + item);
            }

            var task = mapper.Map<ProgrammingTaskResource, ProgrammingTask>(taskResource);

            // task = await dbContext.Tasks.SingleOrDefaultAsync(t => t.Id == task.Id);

            // task = await dbContext.Tasks
            //     .Include(pt => pt.ProgrammingLanguages)
            //         .ThenInclude(tl => tl.Language)
            //     .SingleOrDefaultAsync(t => t.Id == task.Id);

            dbContext.Add(task);

            await dbContext.SaveChangesAsync();

            task = await dbContext.Tasks.SingleOrDefaultAsync(t => t.Id == task.Id);

            /*
             * This is working so far.
             * I am able to add a Programming language to the task which is then returned in the response.
             * The TaskLanguage isn't being saved to the database yet, but I at least have the info needed to do that.
             */
            foreach (var item in taskResource.ProgrammingLanguages)
            {
                task.ProgrammingLanguages.Add(
                    new TaskLanguage {
                    TaskId = task.Id,
                    LanguageId = item
                });
            }

            Console.WriteLine("Task after saving: " + task.Id);
            foreach (var item in task.ProgrammingLanguages)
            {
                Console.WriteLine("Languages after saving Task: " + item.LanguageId);
            }

            // Console.WriteLine("Writing the Task here: " + task.Description);
            // task.ProgrammingLanguages.

            // var taskResult = mapper.Map<ProgrammingTask, ProgrammingTaskResource>(task);
            return Ok(task);
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateTask([FromBody] ProgrammingTask task)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     return Ok(task);
        // }

        [HttpGet]
        public async Task<IEnumerable<SaveProgrammingTaskResource>> GetTasks()
        {
            var tasks = await dbContext.Tasks
                .Include(pt => pt.ProgrammingLanguages)
                    .ThenInclude(tl => tl.Language)
                .ToListAsync();
            return mapper.Map<List<ProgrammingTask>, List<SaveProgrammingTaskResource>>(tasks);
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