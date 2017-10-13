using System.ComponentModel.DataAnnotations;

namespace ProgrammingLog.Models
{
    public class ProgrammingLanguage
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Language { get; set; }
    }
}