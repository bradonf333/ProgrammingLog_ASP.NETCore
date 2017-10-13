using Microsoft.EntityFrameworkCore;

namespace ProgrammingLog.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Task> Task { get; set; }
    }
}