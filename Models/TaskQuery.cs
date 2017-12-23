using System;

namespace ProgrammingLog.Models
{
    public class TaskQuery
    {
        public double? Hours { get; set; }
        public int? LanguageId { get; set; }
        public string SummaryKeyWord { get; set; }
        public string Description { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }

    }
}