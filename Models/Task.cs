using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingLog.Models
{
    [Table("Tasks")]
    public class Task
    {
        public int Id { get; set; }
        
        [Required]
        public double Hours { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Summary { get; set; }

        [Required]
        public DateTime TaskDate { get; set; }

        public IList<ProgrammingLanguage> Languages { get; set; }

        public Task()
        {
            Languages = new List<ProgrammingLanguage>();
        }

    }
}