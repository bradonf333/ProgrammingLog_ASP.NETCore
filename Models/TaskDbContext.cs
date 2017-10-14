using Microsoft.EntityFrameworkCore;

namespace ProgrammingLog.Models
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskLanguage>().HasKey(tl => new
            {
                tl.TaskId,
                tl.LanguageId
            });
        }
    }
}