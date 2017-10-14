using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingLog.Models;

namespace ProgrammingLog.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly TaskDbContext dbContext;
        public LanguagesController(TaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("/api/Languages")]
        public async Task<IEnumerable<ProgrammingLanguage>> GetLanguages()
        {
            return await dbContext.ProgrammingLanguages.ToListAsync();
        }
    }
}