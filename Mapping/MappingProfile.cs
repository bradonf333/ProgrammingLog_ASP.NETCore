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
            CreateMap<ProgrammingTask, ProgrammingTaskResource>()
            .ForMember(ptr => ptr.Languages, opt => opt.MapFrom(pt => pt.Languages.Select(
                tl => tl.LanguageId
            )));
            CreateMap<ProgrammingLanguage, KeyValuePairResource>();

            // API Resource to Domain
        }
    }
}