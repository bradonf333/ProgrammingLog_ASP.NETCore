using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProgrammingLog.Controllers.Resources;
using ProgrammingLog.Models;

namespace ProgrammingLog.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            // CreateMap<Source, Destination>
            CreateMap<TaskQueryResource, TaskQuery>();
            CreateMap<ProgrammingTask, SaveProgrammingTaskResource>()
            .ForMember(ptr => ptr.Languages, opt => opt.MapFrom(pt => pt.ProgrammingLanguages.Select(
                tl => new ProgrammingLanguage
                {
                    Id = tl.Language.Id,
                    Language = tl.Language.Language
                }
            )));
            CreateMap<ProgrammingTask, ProgrammingTaskResource>()
            .ForMember(ptr => ptr.ProgrammingLanguages, opt => opt.MapFrom(pt => pt.ProgrammingLanguages.Select(
                tl => new ProgrammingLanguage
                {
                    Id = tl.Language.Id,
                    Language = tl.Language.Language
                }
            )));

            // API Resource to Domain
            // CreateMap<Source, Destination>
            CreateMap<ProgrammingTaskResource, ProgrammingTask>()
                .ForMember(pt => pt.Id, opt => opt.Ignore())
                .ForMember(pt => pt.ProgrammingLanguages, opt => opt.Ignore())
                .AfterMap((ptr, pt) =>
                {
                    var languages = ptr.ProgrammingLanguages
                    .Where(id => pt.ProgrammingLanguages
                        .Any(tl => tl.LanguageId == id))
                    .Select(id => new TaskLanguage { LanguageId = id, TaskId = pt.Id });

                    foreach (var taskLanguage in languages)
                    {
                        pt.ProgrammingLanguages.Add(taskLanguage);
                    }

                });
                CreateMap<UpdateProgrammingTaskResource, ProgrammingTask>()
                .ForMember(pt => pt.Id, opt => opt.Ignore())
                .ForMember(pt => pt.ProgrammingLanguages, opt => opt.Ignore())
                .AfterMap((ptr, pt) =>
                {
                    // Remove TaskLanguages
                    var removedTaskLanguages = new List<TaskLanguage>();

                    foreach (var taskLanguage in pt.ProgrammingLanguages)
                    {
                        if (!ptr.ProgrammingLanguages.Contains(taskLanguage.LanguageId))
                        {
                            removedTaskLanguages.Add(taskLanguage);
                        }
                    }

                    // -This is supposed to be a LINQ version of the loop above, but it doesn't work for some reason.
                    // var removedTaskLanguages = pt.ProgrammingLanguages.Where(taskLanguage => !ptr.ProgrammingLanguages.Contains(taskLanguage.LanguageId));

                    foreach (var taskLanguage in removedTaskLanguages)
                    {
                        pt.ProgrammingLanguages.Remove(taskLanguage);
                    }

                    // Add TaskLanguages
                    var addedTaskLanguages = ptr.ProgrammingLanguages
                        .Where(id => !pt.ProgrammingLanguages
                            .Any(tl => tl.LanguageId == id))
                        .Select(id => new TaskLanguage { LanguageId = id, TaskId = pt.Id });

                    foreach (var taskLanguage in addedTaskLanguages)
                    {
                        pt.ProgrammingLanguages.Add(taskLanguage);
                    }

                });
        }
    }
}