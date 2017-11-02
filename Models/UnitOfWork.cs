using System.Threading.Tasks;

namespace ProgrammingLog.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext dbContext;
        public UnitOfWork(TaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}