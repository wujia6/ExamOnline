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
                .ForMember(dest => dest.ClassTeachers, opts => opts.MapFrom(src => src.ClassTeacherDtos));
            CreateMap<TeacherInfo, TeacherDTO>();

            CreateMap<StudentDTO, StudentInfo>()
                .ForMember(dest => dest.ClassInfo, opts => opts.MapFrom(src => src.ClassDto))
                .ForMember(dest => dest.AnswerInfos, opts => opts.MapFrom(src => src.AnswerDtos));
            CreateMap<StudentInfo, StudentDTO>();

            CreateMap<QuestionDTO, QuestionInfo>()
                .ForMember(dest => dest.ExamInfo, opts => opts.MapFrom(src => src.ExamDto));
            CreateMap<QuestionInfo, QuestionDTO>();

            CreateMap<ExamDTO, ExamInfo>()
                .ForMember(dest => dest.TeacherInfos, opts => opts.MapFrom(src => src.TeacherDtos))
                .ForMember(dest => dest.ClassExams, opts => opts.MapFrom(src => src.ClassExamDtos))
                .ForMember(dest => dest.QuestionInfos, opts => opts.MapFrom(src => src.QuestionDtos))
                .ForMember(dest => dest.AnswerInfos, opts => opts.MapFrom(src => src.AnswerDtos));
            CreateMap<ExamInfo, ExamDTO>();

            CreateMap<ClassDTO, ClassInfo>()
                .ForMember(dest => dest.ClassExams, opts => opts.MapFrom(src => src.ClassExamDtos))
                .ForMember(dest => dest.ClassTeachers, opts => opts.MapFrom(src => src.ClassTeacherDtos))
                .ForMember(dest => dest.StudentInfos, opts => opts.MapFrom(src => src.StudentDtos));
            CreateMap<ClassInfo, ClassDTO>();

            CreateMap<ClassExamDTO, ClassExam>()
                .ForMember(dest => dest.ClassInfo, opts => opts.MapFrom(src => src.ClassDto))
                .ForMember(dest => dest.ExamInfo, opts => opts.MapFrom(src => src.ExamDto));
            CreateMap<ClassExam, ClassExamDTO>();

            CreateMap<ClassTeacherDTO, ClassTeacher>()
                .ForMember(dest => dest.ClassInfo, opts => opts.MapFrom(src => src.ClassDto))
                .ForMember(dest => dest.TeacherInfo, opts => opts.MapFrom(src => src.TeacherDto));
            CreateMap<ClassTeacher, ClassTeacherDTO>();

            CreateMap<AnswerDTO, AnswerInfo>()
                .ForMember(dest => dest.ExamInfo, opts => opts.MapFrom(src => src.ExamDTO))
                .ForMember(dest => dest.StudentInfo, opts => opts.MapFrom(src => src.StudentDTO));
            CreateMap<AnswerInfo, AnswerDTO>();
        }

        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new RuleConfig()));
        }
    }
}
