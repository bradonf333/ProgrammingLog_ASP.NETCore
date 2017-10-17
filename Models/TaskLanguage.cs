using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingLog.Models
{
    [Table("TaskLanguages")]
    public class TaskLanguage
    {
        public int TaskId { get; set; }
        public int LanguageId { get; set; }
        public ProgrammingTask Task { get; set; }
        public ProgrammingLanguage Language { get; set; }
    }
}