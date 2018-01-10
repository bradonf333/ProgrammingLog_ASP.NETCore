using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgrammingLog.Models
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext dbContext;
        public TaskRepository(TaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ProgrammingTask> GetTaskAsync(int id, bool includeTaskLanguages = true)
        {
            if(!includeTaskLanguages)
            {
                return await dbContext.Tasks.FindAsync(id);
            }
            return await dbContext.Tasks
                .Include(pt => pt.ProgrammingLanguages)
                    .ThenInclude(tl => tl.Language)
                .SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IList<ProgrammingTask>> GetAllTasksAsync(TaskQuery queryObj, bool includeTaskLanguages = true)
        {
            if(!includeTaskLanguages)
            {
                return await dbContext.Tasks.ToListAsync();
            }

            var query = dbContext.Tasks
                .Include(pt => pt.ProgrammingLanguages)
                    .ThenInclude(tl => tl.Language)
                .AsQueryable();

            if (queryObj.LanguageId.HasValue)
            {
                query = query.Where(pt => pt.ProgrammingLanguages.Any(pl => pl.LanguageId == queryObj.LanguageId));
            }

            if (queryObj.SortBy == "taskDate")
            {
                query = (queryObj.IsSortAscending) ? query.OrderBy(pt => pt.TaskDate) : query.OrderByDescending(pt => pt.TaskDate);
            }
            if (queryObj.SortBy == "taskHours")
            {
                query = (queryObj.IsSortAscending) ? query.OrderBy(pt => pt.Hours) : query.OrderByDescending(pt => pt.Hours);
            }
            if (queryObj.SortBy == "taskSummary")
            {
                query = (queryObj.IsSortAscending) ? query.OrderBy(pt => pt.Summary) : query.OrderByDescending(pt => pt.Summary);
            }
            if (queryObj.SortBy == "id")
            {
                query = (queryObj.IsSortAscending) ? query.OrderBy(pt => pt.Id) : query.OrderByDescending(pt => pt.Id);
            }
            
            // if (!String.IsNullOrEmpty(queryObj.SummaryKeyWord))
            // {
            //     query = query.Where(pt => pt.Summary.Contains(queryObj.SummaryKeyWord));
            // }
            // else if (!String.IsNullOrEmpty(queryObj.Description))
            // {
            //     query = query.Where(pt => pt.Description.Contains(queryObj.Description));
            // }

            return await query.ToListAsync();
        }

        public void Add(ProgrammingTask task)
        {
            dbContext.Tasks.Add(task);
        }

        public void Remove(ProgrammingTask task)
        {
            dbContext.Tasks.Remove(task);
        }
        
    }
}