using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingLog.Models
{
    [Table("ProgrammingLanguages")]
    public class ProgrammingLanguage
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Language { get; set; }
    }
}