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
                tl => new ProgrammingLanguage { 
                    Id = tl.Language.Id, 
                    Language = tl.Language.Language 
                    }
            )));
            CreateMap<ProgrammingTask, ProgrammingTaskResource>()
            .ForMember(ptr => ptr.ProgrammingLanguages, opt => opt.MapFrom(pt => pt.ProgrammingLanguages.Select(
                tl => new ProgrammingLanguage { 
                    Id = tl.Language.Id, 
                    Language = tl.Language.Language 
                    }
            )));

            // --This was mapping to get only the LanguageId not the language object
            // .ForMember(ptr => ptr.Languages, opt => opt.MapFrom(pt => pt.ProgrammingLanguages.Select(
            //     pl => pl.LanguageId
            // )))

            // API Resource to Domain
            // CreateMap<Source, Destination>
            CreateMap<ProgrammingTaskResource, ProgrammingTask>()
                .ForMember(pt => pt.Id, opt => opt.Ignore())
                .ForMember(pt => pt.ProgrammingLanguages, opt => opt.Ignore())
                .AfterMap((ptr, pt) => 
                {
                    var languages = ptr.ProgrammingLanguages.Where(id => pt.ProgrammingLanguages.Any(l => l.LanguageId == id))
                        .Select(id => new TaskLanguage { LanguageId = id, TaskId = pt.Id});

                        foreach (var item in languages)
                        {
                            pt.ProgrammingLanguages.Add(item);
                        }

                });
                
                
                // pt => pt.ProgrammingLanguages, opt => opt.MapFrom(ptr => ptr.ProgrammingLanguages.Select(
                //     tl => new TaskLanguage {
                //         TaskId = ptr.Id,
                //         LanguageId = tl.Id
                //     }
                // )));
                // .ForMember(pt => pt.ProgrammingLanguages, opt => opt.Ignore())
                // .AfterMap((ptr, pt) =>
                // {
                //     var removedLanguages = pt.ProgrammingLanguages.Where(languages => !ptr.Languages.Contains(languages.Language));

                //     foreach (var language in removedLanguages)
                //     {
                //         pt.ProgrammingLanguages.Remove(language);
                //     }

                //     var addedLanguages = ptr.Languages.Where(id => !pt.ProgrammingLanguages.Any(tl => tl.LanguageId == id))
                // });
        }
    }
}