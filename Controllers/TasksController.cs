using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingLog.Controllers.Resources;
using ProgrammingLog.Models;

namespace ProgrammingLog.Controllers
{
    public class TasksController
    {
        private readonly TaskDbContext dbContext;
        private readonly IMapper mapper;
        public TasksController(TaskDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        [HttpGet("/api/tasks")]
        public async Task<IEnumerable<ProgrammingTaskResource>> GetTasks()
        {
            var tasks = await dbContext.Tasks.Include(l => l.Languages).ToListAsync();
            return mapper.Map<List<ProgrammingTask>, List<ProgrammingTaskResource>>(tasks);
        }
    }
}