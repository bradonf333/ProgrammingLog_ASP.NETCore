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
        }
    }
}