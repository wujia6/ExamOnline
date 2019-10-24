using System.Collections.Generic;
using AutoMapper;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.UserAgg;

namespace Application.DTO
{
    /// <summary>
    /// DTO映射配置类
    /// </summary>
    public class MapperRuleConfig: Profile
    {
        public MapperRuleConfig()
        {
            Mapper.Initialize(cfg =>
            {
                #region entity ==> dto
                cfg.CreateMap<ClassInfo, ClassDTO>()
                    .ForMember(dest => dest.ClassExamDtos, opts =>
                        opts.MapFrom(src => Mapper.Map<IEnumerable<ClassExam>, List<ClassExamDTO>>(src.ClassExams)))
                    .ForMember(dest => dest.ClassTeacherDtos, opts =>
                        opts.MapFrom(src => Mapper.Map<IEnumerable<ClassTeacher>, List<ClassTeacherDTO>>(src.ClassTeachers)))
                    .ForMember(dest => dest.StudentDtos, opts =>
                        opts.MapFrom(src => Mapper.Map<IEnumerable<StudentInfo>, List<StudentDTO>>(src.StudentInfomations)));

                cfg.CreateMap<ClassExam, ClassExamDTO>()
                    .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
                    .ForMember(dest => dest.ExamDto, opts => opts.MapFrom(src => src.ExamInfomation));

                cfg.CreateMap<ClassTeacher, ClassTeacherDTO>()
                    .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
                    .ForMember(dest => dest.TeacherDto, opts => opts.MapFrom(src => src.TeacherInfomation));

                cfg.CreateMap<AdminInfo, AdminDTO>();

                cfg.CreateMap<TeacherInfo, TeacherDTO>()
                    .ForMember(dest => dest.ClassTeacherDtos, opts =>
                        opts.MapFrom(src => Mapper.Map<IEnumerable<ClassTeacher>, List<ClassTeacherDTO>>(src.ClassTeachers)));

                cfg.CreateMap<StudentInfo, StudentDTO>()
                    .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
                    .ForMember(dest => dest.AnswerDtos, opts =>
                        opts.MapFrom(src => Mapper.Map<IEnumerable<AnswerInfo>, List<AnswerDTO>>(src.AnswerInfomations)));

                cfg.CreateMap<QuestionInfo, QuestionDTO>()
                    .ForMember(dest => dest.ExamDto, opts => opts.MapFrom(src => src.ExamInfomation));

                cfg.CreateMap<ExamInfo, ExamDTO>()
                    .ForMember(dest => dest.TeacherDtos, opts =>
                        opts.MapFrom(src => Mapper.Map<IEnumerable<TeacherInfo>, List<TeacherDTO>>(src.TeacherInfomations)))
                    .ForMember(dest => dest.ClassExamDtos, opts =>
                        opts.MapFrom(src => Mapper.Map<IEnumerable<ClassExam>, List<ClassExamDTO>>(src.ClassExams)))
                    .ForMember(dest => dest.QuestionDtos, opts =>
                        opts.MapFrom(src => Mapper.Map<IEnumerable<QuestionInfo>, List<QuestionDTO>>(src.QuestionInfomations)))
                    .ForMember(dest => dest.AnswerDtos, opts =>
                        opts.MapFrom(src => Mapper.Map<IEnumerable<AnswerInfo>, List<AnswerDTO>>(src.AnswerInfomations)));

                cfg.CreateMap<AnswerInfo, AnswerDTO>()
                    .ForMember(dest => dest.ExamDto, opts => opts.MapFrom(src => src.ExamInfomation))
                    .ForMember(dest => dest.StudentDto, opts => opts.MapFrom(src => src.StudentInfomation));
                #endregion
                #region dto ==> entity
                cfg.CreateMap<ClassDTO, ClassInfo>()
                    .ForMember(dest => dest.ClassExams, opts =>
                        opts.MapFrom(src => Mapper.Map<List<ClassExamDTO>, IEnumerable<ClassExam>>(src.ClassExamDtos)))
                    .ForMember(dest => dest.ClassTeachers, opts =>
                        opts.MapFrom(src => Mapper.Map<List<ClassTeacherDTO>, IEnumerable<ClassTeacher>>(src.ClassTeacherDtos)))
                    .ForMember(dest => dest.StudentInfomations, opts =>
                        opts.MapFrom(src => Mapper.Map<List<StudentDTO>, IEnumerable<StudentInfo>>(src.StudentDtos)));

                cfg.CreateMap<ClassExamDTO, ClassExam>()
                    .ForMember(dest => dest.ClassInfomation, opts => opts.MapFrom(src => src.ClassDto))
                    .ForMember(dest => dest.ExamInfomation, opts => opts.MapFrom(src => src.ExamDto));

                cfg.CreateMap<ClassTeacherDTO, ClassTeacher>()
                    .ForMember(dest => dest.ClassInfomation, opts => opts.MapFrom(src => src.ClassDto))
                    .ForMember(dest => dest.TeacherInfomation, opts => opts.MapFrom(src => src.TeacherDto));

                cfg.CreateMap<AdminDTO, AdminInfo>();

                cfg.CreateMap<TeacherDTO, TeacherInfo>()
                    .ForMember(dest => dest.ClassTeachers, opts =>
                        opts.MapFrom(src => Mapper.Map<List<ClassTeacherDTO>, IEnumerable<ClassTeacher>>(src.ClassTeacherDtos)));

                cfg.CreateMap<StudentDTO, StudentInfo>()
                    .ForMember(dest => dest.ClassInfomation, opts => opts.MapFrom(src => src.ClassDto))
                    .ForMember(dest => dest.AnswerInfomations, opts =>
                        opts.MapFrom(src => Mapper.Map<List<AnswerDTO>, IEnumerable<AnswerInfo>>(src.AnswerDtos)));

                cfg.CreateMap<QuestionDTO, QuestionInfo>()
                    .ForMember(dest => dest.ExamInfomation, opts => opts.MapFrom(src => src.ExamDto));

                cfg.CreateMap<ExamDTO, ExamInfo>()
                    .ForMember(dest => dest.TeacherInfomations, opts =>
                        opts.MapFrom(src => Mapper.Map<List<TeacherDTO>, IEnumerable<TeacherInfo>>(src.TeacherDtos)))
                    .ForMember(dest => dest.ClassExams, opts =>
                        opts.MapFrom(src => Mapper.Map<List<ClassExamDTO>, IEnumerable<ClassExam>>(src.ClassExamDtos)))
                    .ForMember(dest => dest.QuestionInfomations, opts =>
                        opts.MapFrom(src => Mapper.Map<List<QuestionDTO>, IEnumerable<QuestionInfo>>(src.QuestionDtos)))
                    .ForMember(dest => dest.AnswerInfomations, opts =>
                        opts.MapFrom(src => Mapper.Map<List<AnswerDTO>, IEnumerable<AnswerInfo>>(src.AnswerDtos)));

                cfg.CreateMap<AnswerDTO, AnswerInfo>()
                    .ForMember(dest => dest.ExamInfomation, opts => opts.MapFrom(src => src.ExamDto))
                    .ForMember(dest => dest.StudentInfomation, opts => opts.MapFrom(src => src.StudentDto));
                #endregion
            });
        }

        /// <summary>
        /// 初始化自定义profile
        /// </summary>
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new MapperRuleConfig()));
        }
    }
}
