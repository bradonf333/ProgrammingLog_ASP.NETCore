using System;
using System.Collections.Generic;
using ProgrammingLog.Models;

namespace ProgrammingLog.Controllers.Resources
{
    public class ProgrammingTaskResource
    {
        public int Id { get; set; }

        public double Hours { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }

        public DateTime TaskDate { get; set; }

        public IList<int> ProgrammingLanguages { get; set; }

        public ProgrammingTaskResource()
        {
            ProgrammingLanguages = new List<int>();
        }
    }
}