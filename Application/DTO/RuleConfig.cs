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
            CreateMap<AdminInfo, AdminDTO>();
            CreateMap<AdminInfo, AdminDTO>();

            CreateMap<TeacherInfo, TeacherDTO>()
                .ForMember(dest => dest.ClassTeacherDtos, opts => opts.MapFrom(src => src.ClassTeachers));
            CreateMap<TeacherDTO, TeacherInfo>();

            CreateMap<StudentInfo, StudentDTO>()
                .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
                .ForMember(dest => dest.AnswerDtos, opts => opts.MapFrom(src => src.AnswerInfomations));
            CreateMap<StudentDTO, StudentInfo>();

            CreateMap<QuestionInfo, QuestionDTO>()
                .ForMember(dest => dest.ExamDto, opts => opts.MapFrom(src => src.ExamInfomation));
            CreateMap<QuestionDTO, QuestionInfo>();

            CreateMap<ExamInfo, ExamDTO>()
                .ForMember(dest => dest.TeacherDtos, opts => opts.MapFrom(src => src.TeacherInfomations))
                .ForMember(dest => dest.ClassExamDtos, opts => opts.MapFrom(src => src.ClassExams))
                .ForMember(dest => dest.QuestionDtos, opts => opts.MapFrom(src => src.QuestionInfomations))
                .ForMember(dest => dest.AnswerDtos, opts => opts.MapFrom(src => src.AnswerInfomations));
            CreateMap<ExamDTO, ExamInfo>();

            CreateMap<ClassInfo, ClassDTO>()
                .ForMember(dest => dest.ClassExamDtos, opts => opts.MapFrom(src => src.ClassExams))
                .ForMember(dest => dest.ClassTeacherDtos, opts => opts.MapFrom(src => src.ClassTeachers))
                .ForMember(dest => dest.StudentDtos, opts => opts.MapFrom(src => src.StudentInfomations));
            CreateMap<ClassDTO, ClassInfo>();

            CreateMap<ClassExam, ClassExamDTO>()
                .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
                .ForMember(dest => dest.ExamDto, opts => opts.MapFrom(src => src.ExamInfomation));
            CreateMap<ClassExamDTO, ClassExam>();

            CreateMap<ClassTeacher, ClassTeacherDTO>()
                .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
                .ForMember(dest => dest.TeacherDto, opts => opts.MapFrom(src => src.TeacherInfomation));
            CreateMap<ClassTeacherDTO, ClassTeacher>();

            CreateMap<AnswerInfo, AnswerDTO>()
                .ForMember(dest => dest.ExamDto, opts => opts.MapFrom(src => src.ExamInfomation))
                .ForMember(dest => dest.StudentDto, opts => opts.MapFrom(src => src.StudentInfomation));
            CreateMap<AnswerDTO, AnswerInfo>();
        }

        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new RuleConfig()));
        }
    }
}
