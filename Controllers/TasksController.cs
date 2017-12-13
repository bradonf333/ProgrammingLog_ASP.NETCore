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
        private readonly ITaskRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public TasksController(TaskDbContext dbContext, IMapper mapper, ITaskRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
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

            repository.Add(task);

            await unitOfWork.CompleteAsync();

            task = await repository.GetTaskAsync(task.Id);

            foreach (var id in taskResource.ProgrammingLanguages)
            {
                task.ProgrammingLanguages.Add(
                    new TaskLanguage
                    {
                        TaskId = task.Id,
                        LanguageId = id
                    });
            }

            await unitOfWork.CompleteAsync();

            task = await repository.GetTaskAsync(task.Id); // Is this one necessary??? Maybe it is because the task above didn't have the TaskLanguages??

            var taskResult = mapper.Map<ProgrammingTask, SaveProgrammingTaskResource>(task);
            return Ok(taskResult);
        }

        [HttpGet]
        public async Task<IList<SaveProgrammingTaskResource>> GetTasks(FilterResource filterResource)
        {
            var filter = mapper.Map<FilterResource, Filter>(filterResource);
            var tasks = await repository.GetAllTasksAsync(filter);
            return mapper.Map<IList<ProgrammingTask>, List<SaveProgrammingTaskResource>>(tasks);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateProgrammingTaskResource taskResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await repository.GetTaskAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            mapper.Map<UpdateProgrammingTaskResource, ProgrammingTask>(taskResource, task);

            await unitOfWork.CompleteAsync();

            task = await repository.GetTaskAsync(id);

            var taskResult = mapper.Map<ProgrammingTask, SaveProgrammingTaskResource>(task);

            return Ok(taskResult);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await repository.GetTaskAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            repository.Remove(task);

            await unitOfWork.CompleteAsync();

            return Ok(id);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await repository.GetTaskAsync(id); ;

            var taskResult = mapper.Map<ProgrammingTask, SaveProgrammingTaskResource>(task);

            return Ok(taskResult);
        }
    }
}