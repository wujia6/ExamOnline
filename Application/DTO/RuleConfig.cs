using AutoMapper;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.UserAgg;

namespace Application.DTO
{
    /// <summary>
    /// 映射规则配置类
    /// </summary>
    public class RuleConfig : Profile
    {
        public RuleConfig()
        {
            CreateMap<AdminDTO, AdminInfo>();
            CreateMap<AdminInfo, AdminDTO>();

            CreateMap<TeacherDTO, TeacherInfo>()
                .ForMember(dest => dest.ClassInfos, opts => opts.MapFrom(src => src.Classes));
            CreateMap<TeacherInfo, TeacherDTO>();

            CreateMap<StudentDTO, StudentInfo>()
                .ForMember(dest => dest.ClassInfo, opts => opts.MapFrom(src => src.ClassInfo))
                .ForMember(dest => dest.AnswerInfos, opts => opts.MapFrom(src => src.AnswerInfos));
            CreateMap<StudentInfo, StudentDTO>();

            CreateMap<QuestionDTO, QuestionInfo>()
                .ForMember(dest => dest.ExamInfo, opts => opts.MapFrom(src => src.ExamInfo));
            CreateMap<QuestionInfo, QuestionDTO>();

            CreateMap<ExamDTO, ExamInfo>()
                .ForMember(dest => dest.Teachers, opts => opts.MapFrom(src => src.Teachers))
                .ForMember(dest => dest.ClassInfos, opts => opts.MapFrom(src => src.ClassInfos))
                .ForMember(dest => dest.QuestionInfos, opts => opts.MapFrom(src => src.QuestionInfos))
                .ForMember(dest => dest.AnswerInfos, opts => opts.MapFrom(src => src.AnswerInfos));
            CreateMap<ExamInfo, ExamDTO>();

            CreateMap<ClassDTO, ClassInfo>()
                .ForMember(dest => dest.ExamInfos, opts => opts.MapFrom(src => src.ExamInfos))
                .ForMember(dest => dest.TeacherInfos, opts => opts.MapFrom(src => src.Teachers))
                .ForMember(dest => dest.StudentInfos, opts => opts.MapFrom(src => src.Students));
            CreateMap<ClassInfo, ClassDTO>();

            CreateMap<ClassExamDTO, ClassExam>()
                .ForMember(dest => dest.ClassInfo, opts => opts.MapFrom(src => src.ClassInfo))
                .ForMember(dest => dest.ExamInfo, opts => opts.MapFrom(src => src.ExamInfo));
            CreateMap<ClassExam, ClassExamDTO>();

            CreateMap<ClassTeacherDTO, ClassTeacher>()
                .ForMember(dest => dest.ClassInfo, opts => opts.MapFrom(src => src.ClassInfo))
                .ForMember(dest => dest.TeacherInfo, opts => opts.MapFrom(src => src.Teacher));
            CreateMap<ClassTeacher, ClassTeacherDTO>();

            CreateMap<AnswerDTO, AnswerInfo>()
                .ForMember(dest => dest.ExamInfo, opts => opts.MapFrom(src => src.ExamInfo))
                .ForMember(dest => dest.StudentInfo, opts => opts.MapFrom(src => src.Student));
            CreateMap<AnswerInfo, AnswerDTO>();
        }

        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new RuleConfig()));
        }
    }
}
