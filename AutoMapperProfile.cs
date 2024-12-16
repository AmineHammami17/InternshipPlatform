using AutoMapper;
using InternshipPlatform.Models.DTO;

namespace InternshipPlatform
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<InternshipDocument, InternshipDocumentDto>();
            CreateMap<Evaluation, EvaluationDto>();
            CreateMap<Intern, InternDto>();
            CreateMap<InternshipProgress, ProgressDto>();
            CreateMap<Internships, InternshipDto>();
            CreateMap<Supervisor, SupervisorDto>();

        }
    }
}
