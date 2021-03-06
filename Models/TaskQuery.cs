using System;
using ProgrammingLog.Extensions;

namespace ProgrammingLog.Models
{
    public class TaskQuery : IQueryObject
    {
        public double Hours { get; set; }
        public int? LanguageId { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskSummary { get; set; }
        // public string Description { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}