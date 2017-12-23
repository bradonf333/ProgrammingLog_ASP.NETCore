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

        public async Task<IList<ProgrammingTask>> GetAllTasksAsync(TaskQuery filter, bool includeTaskLanguages = true)
        {
            if(!includeTaskLanguages)
            {
                return await dbContext.Tasks.ToListAsync();
            }

            var query = dbContext.Tasks
                .Include(pt => pt.ProgrammingLanguages)
                    .ThenInclude(tl => tl.Language)
                .AsQueryable();

            if (filter.LanguageId.HasValue)
            {
                query = query.Where(pt => pt.ProgrammingLanguages.Any(pl => pl.LanguageId == filter.LanguageId));
            }
            
            if (!String.IsNullOrEmpty(filter.SummaryKeyWord))
            {
                query = query.Where(pt => pt.Summary.Contains(filter.SummaryKeyWord));
            }
            else if (!String.IsNullOrEmpty(filter.Description))
            {
                query = query.Where(pt => pt.Description.Contains(filter.Description));
            }

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