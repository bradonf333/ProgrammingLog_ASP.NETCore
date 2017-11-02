using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgrammingLog.Models
{
    public interface ITaskRepository
    {
         Task<ProgrammingTask> GetTaskAsync(int id, bool includeTaskLanguages = true);
         Task<IList<ProgrammingTask>> GetAllTasksAsync(bool includeTaskLanguages = true);
         void Add(ProgrammingTask task);
         void Remove(ProgrammingTask task);
    }
}