using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgrammingLog.Extensions;

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

            // Can't remember what this was for, but I had it here before I switch to sorting via the server.
            // Leaving here for now.
            // if (queryObj.LanguageId.HasValue)
            // {
            //     query = query.Where(pt => pt.ProgrammingLanguages.Any(pl => pl.LanguageId == queryObj.LanguageId));
            // }
            

            // Create a LINQ mapping for the columns that are available to sort by. 
            var columnsMap = new Dictionary<string, Expression<Func<ProgrammingTask, object>>>()
            {
                ["taskDate"] = pt => pt.TaskDate,
                ["taskHours"] = pt => pt.Hours,
                ["taskSummary"] = pt => pt.Summary
                // ["id"] = pt => pt.Id
            };

            // Apply sorting based on the columnsMap & IsSortAsc value, which are both given in the Query String
            // query = ApplyOrdering(queryObj, query, columnsMap);
            query = query.ApplyOrdering(queryObj, columnsMap);
            
            query = query.ApplyPaging(queryObj);
            
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

        private IQueryable<ProgrammingTask> ApplyOrdering(
            TaskQuery queryObj, 
            IQueryable<ProgrammingTask> query,
            Dictionary<string, Expression<Func<ProgrammingTask,object>>> columnsMap)
        {
            // Apply sorting based on the columnsMap & IsSortAsc value, which are both given in the Query String
            if(queryObj.IsSortAscending)
            {
                query = query.OrderBy(columnsMap[queryObj.SortBy]);
            }
            else
            {
                query = query.OrderByDescending(columnsMap[queryObj.SortBy]);
            }

            return query;
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