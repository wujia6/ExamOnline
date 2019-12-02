using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.RoleAgg;
using Domain.Entities.UserAgg;

namespace Application.DTO
{
    /// <summary>
    /// DTO映射规则类
    /// </summary>
    public class RuleConfig: Profile
    {
        public RuleConfig()
        {
            #region entity ==> dto
            CreateMap<ClassInfo, ClassDTO>()
                .ForMember(dest => dest.ClassExaminationDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IQueryable<ClassExamination>, List<ClassExaminationDTO>>(src.ClassExams)))
                .ForMember(dest => dest.ClassTeacherDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IQueryable<ClassTeacher>, List<ClassTeacherDTO>>(src.ClassTeachers)))
                .ForMember(dest => dest.StudentDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IQueryable<StudentInfo>, List<StudentDTO>>(src.StudentInfomations)));

            CreateMap<ClassExamination, ClassExaminationDTO>()
                .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
                .ForMember(dest => dest.ExaminationDto, opts => opts.MapFrom(src => src.ExamInfomation));

            CreateMap<ClassTeacher, ClassTeacherDTO>()
                .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
                .ForMember(dest => dest.TeacherDto, opts => opts.MapFrom(src => src.TeacherInfomation));

            CreateMap<RoleInfo, RoleDTO>()
                .ForMember(dest => dest.RoleMenuDtos, opts => opts.MapFrom(src => Mapper.Map<IQueryable<RoleMenu>, List<RoleMenuDTO>>(src.RoleMenus)))
                .ForMember(dest => dest.UserRoleDtos, opts => opts.MapFrom(src => Mapper.Map<IEnumerable<UserRole>, List<UserRoleDTO>>(src.UserRoles)));

            CreateMap<UserRole, UserRoleDTO>()
                .ForMember(dest => dest.RoleDto, opts => opts.MapFrom(src => src.RoleInfomation))
                .ForMember(dest => dest.UserDto, opts => opts.MapFrom(src => src.UserInfomation));

            CreateMap<UserInfo, UserDTO>()
                .ForMember(dest => dest.UserRoleDtos, opts => opts.MapFrom(src => Mapper.Map<IEnumerable<UserRole>, List<UserRoleDTO>>(src.UserRoles)));

            CreateMap<TeacherInfo, TeacherDTO>()
                .ForMember(dest => dest.ClassTeacherDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IQueryable<ClassTeacher>, List<ClassTeacherDTO>>(src.ClassTeachers)));

            CreateMap<StudentInfo, StudentDTO>()
                .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
                .ForMember(dest => dest.AnswerDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IQueryable<AnswerInfo>, List<AnswerDTO>>(src.AnswerInfomations)));

            CreateMap<QuestionInfo, QuestionDTO>()
                .ForMember(dest => dest.ExaminationDto, opts => opts.MapFrom(src => src.ExaminationInfomation));

            CreateMap<ExaminationInfo, ExaminationDTO>()
                .ForMember(dest => dest.TeacherDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IQueryable<TeacherInfo>, List<TeacherDTO>>(src.TeacherInfomations)))
                .ForMember(dest => dest.ClassExamDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IQueryable<ClassExamination>, List<ClassExaminationDTO>>(src.ClassExams)))
                .ForMember(dest => dest.QuestionDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IQueryable<QuestionInfo>, List<QuestionDTO>>(src.QuestionInfomations)))
                .ForMember(dest => dest.AnswerDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IQueryable<AnswerInfo>, List<AnswerDTO>>(src.AnswerInfomations)));

            CreateMap<AnswerInfo, AnswerDTO>()
                .ForMember(dest => dest.ExamDto, opts => opts.MapFrom(src => src.ExamInfomation))
                .ForMember(dest => dest.StudentDto, opts => opts.MapFrom(src => src.StudentInfomation));
            #endregion
            #region dto ==> entity
            CreateMap<ClassDTO, ClassInfo>()
                .ForMember(dest => dest.ClassExams, opts =>
                    opts.MapFrom(src => Mapper.Map<List<ClassExaminationDTO>, IQueryable<ClassExamination>>(src.ClassExaminationDtos)))
                .ForMember(dest => dest.ClassTeachers, opts =>
                    opts.MapFrom(src => Mapper.Map<List<ClassTeacherDTO>, IQueryable<ClassTeacher>>(src.ClassTeacherDtos)))
                .ForMember(dest => dest.StudentInfomations, opts =>
                    opts.MapFrom(src => Mapper.Map<List<StudentDTO>, IQueryable<StudentInfo>>(src.StudentDtos)));

            CreateMap<ClassExaminationDTO, ClassExamination>()
                .ForMember(dest => dest.ClassInfomation, opts => opts.MapFrom(src => src.ClassDto))
                .ForMember(dest => dest.ExamInfomation, opts => opts.MapFrom(src => src.ExaminationDto));

            CreateMap<ClassTeacherDTO, ClassTeacher>()
                .ForMember(dest => dest.ClassInfomation, opts => opts.MapFrom(src => src.ClassDto))
                .ForMember(dest => dest.TeacherInfomation, opts => opts.MapFrom(src => src.TeacherDto));

            CreateMap<UserDTO, UserInfo>()
                .ForMember(dest => dest.UserRoles, opts =>
                    opts.MapFrom(src => Mapper.Map<List<UserRoleDTO>, IQueryable<UserRole>>(src.UserRoleDtos)));

            CreateMap<AdminDTO, AdminInfo>();

            CreateMap<TeacherDTO, TeacherInfo>()
                .ForMember(dest => dest.ClassTeachers, opts =>
                    opts.MapFrom(src => Mapper.Map<List<ClassTeacherDTO>, IQueryable<ClassTeacher>>(src.ClassTeacherDtos)));

            CreateMap<StudentDTO, StudentInfo>()
                .ForMember(dest => dest.ClassInfomation, opts => opts.MapFrom(src => src.ClassDto))
                .ForMember(dest => dest.AnswerInfomations, opts =>
                    opts.MapFrom(src => Mapper.Map<List<AnswerDTO>, IQueryable<AnswerInfo>>(src.AnswerDtos)));

            CreateMap<QuestionDTO, QuestionInfo>()
                .ForMember(dest => dest.ExaminationInfomation, opts => opts.MapFrom(src => src.ExaminationDto));

            CreateMap<ExaminationDTO, ExaminationInfo>()
                .ForMember(dest => dest.TeacherInfomations, opts =>
                    opts.MapFrom(src => Mapper.Map<List<TeacherDTO>, IQueryable<TeacherInfo>>(src.TeacherDtos)))
                .ForMember(dest => dest.ClassExams, opts =>
                    opts.MapFrom(src => Mapper.Map<List<ClassExaminationDTO>, IQueryable<ClassExamination>>(src.ClassExamDtos)))
                .ForMember(dest => dest.QuestionInfomations, opts =>
                    opts.MapFrom(src => Mapper.Map<List<QuestionDTO>, IQueryable<QuestionInfo>>(src.QuestionDtos)))
                .ForMember(dest => dest.AnswerInfomations, opts =>
                    opts.MapFrom(src => Mapper.Map<List<AnswerDTO>, IQueryable<AnswerInfo>>(src.AnswerDtos)));

            CreateMap<AnswerDTO, AnswerInfo>()
                .ForMember(dest => dest.ExamInfomation, opts => opts.MapFrom(src => src.ExamDto))
                .ForMember(dest => dest.StudentInfomation, opts => opts.MapFrom(src => src.StudentDto));
            #endregion
        }

        /// <summary>
        /// 初始化DTO映射规则
        /// </summary>
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new RuleConfig()));
        }
    }
}
