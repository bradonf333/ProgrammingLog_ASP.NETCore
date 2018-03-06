using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgrammingLog.Models
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly TaskDbContext dbContext;
        public PhotoRepository(TaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Photo>> GetPhotosAsync(int taskId)
        {
            return await dbContext.Photos
                .Where(p => p.ProgrammingTaskId == taskId)
                .ToListAsync();
        }
    }
}