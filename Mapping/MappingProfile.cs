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
            CreateMap<ProgrammingTask, SaveProgrammingTaskResource>()
            .ForMember(ptr => ptr.Languages, opt => opt.MapFrom(pt => pt.ProgrammingLanguages.Select(
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
        }
    }
}