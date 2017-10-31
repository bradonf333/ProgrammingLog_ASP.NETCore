using System;
using System.Collections.Generic;
using ProgrammingLog.Models;

namespace ProgrammingLog.Controllers.Resources
{
    public class UpdateProgrammingTaskResource
    {
        public double Hours { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }

        public DateTime TaskDate { get; set; }

        public IList<int> ProgrammingLanguages { get; set; }

        public UpdateProgrammingTaskResource()
        {
            ProgrammingLanguages = new List<int>();
        }
    }
}