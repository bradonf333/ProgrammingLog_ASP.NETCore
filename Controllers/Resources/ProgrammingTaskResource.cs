using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProgrammingLog.Models;

namespace ProgrammingLog.Controllers.Resources
{
    public class ProgrammingTaskResource
    {
        public double Hours { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }

        public DateTime TaskDate { get; set; }

        public IList<ProgrammingLanguage> Languages { get; set; }

        public ProgrammingTaskResource()
        {
            Languages = new List<ProgrammingLanguage>();
        }

    }
}