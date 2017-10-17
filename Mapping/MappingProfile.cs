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
            CreateMap<ProgrammingTask, ProgrammingTaskResource>()
            .ForMember(ptr => ptr.Languages, opt => opt.MapFrom(pt => pt.Languages.Select(
                tl => tl.LanguageId
            )));
            CreateMap<TaskLanguage, KeyValuePairResource>();
        }
    }
}