using System;

namespace ProgrammingLog.Controllers.Resources
{
    public class TaskQueryResource
    {
        public double? Hours { get; set; }
        public int? LanguageId { get; set; }
        public string TaskSummary { get; set; }
        public string Description { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}