using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.RoleAgg;
using Domain.Entities.UserAgg;

namespace Application.DTO.Mappings
{
    /// <summary>
    /// DTO映射规则类
    /// </summary>
    public class ProfileBase: Profile
    {
        public ProfileBase()
        {
            #region ###实体模型=>数据模型
            CreateMap<BaseEntity, BaseModel>()
                .Include<RoleInfo, RoleDTO>()
                .Include<RoleMenu, RoleMenuDTO>()
                .Include<UserInfo, UserDTO>()
                .Include<UserRole, UserRoleDTO>()
                .ReverseMap();

            #region 班级
            //CreateMap<ClassInfo, ClassDTO>()
            //    .ForMember(dest => dest.ClassExaminationDtos, opts =>
            //        opts.MapFrom(src => Mapper.Map<IEnumerable<ClassExamination>, List<ClassExaminationDTO>>(src.ClassExams)))
            //    .ForMember(dest => dest.ClassTeacherDtos, opts =>
            //        opts.MapFrom(src => Mapper.Map<IEnumerable<ClassTeacher>, List<ClassTeacherDTO>>(src.ClassTeachers)))
            //    .ForMember(dest => dest.StudentDtos, opts =>
            //        opts.MapFrom(src => Mapper.Map<IEnumerable<StudentInfo>, List<StudentDTO>>(src.StudentInfomations)));

            //CreateMap<ClassExamination, ClassExaminationDTO>()
            //    .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
            //    .ForMember(dest => dest.ExaminationDto, opts => opts.MapFrom(src => src.ExamInfomation));

            //CreateMap<ClassTeacher, ClassTeacherDTO>()
            //    .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
            //    .ForMember(dest => dest.TeacherDto, opts => opts.MapFrom(src => src.TeacherInfomation));
            #endregion

            #region 角色
            CreateMap<RoleMenu, RoleMenuDTO>()
                .ForMember(dest => dest.RoleDto, opts => opts.MapFrom(src => src.RoleInfomation))
                .ForMember(dest => dest.MenuDto, opts => opts.MapFrom(src => src.MenuInfomation))
                .ReverseMap();

            CreateMap<RoleInfo, RoleDTO>()
                .ForMember(dest => dest.RoleMenuDtos, opts => opts.MapFrom(src => Mapper.Map<IEnumerable<RoleMenu>, List<RoleMenuDTO>>(src.RoleMenus)))
                .ForMember(dest => dest.UserRoleDtos, opts => opts.MapFrom(src => Mapper.Map<IEnumerable<UserRole>, List<UserRoleDTO>>(src.UserRoles)))
                .ReverseMap();
            #endregion

            #region 用户
            CreateMap<UserInfo, UserDTO>()
                .Include<AdminInfo,AdminDTO>().ReverseMap();

            CreateMap<AdminInfo, AdminDTO>().ReverseMap();

            CreateMap<AdminInfo, UserDTO>()
                .ForMember(dst => dst.Gender, opts => opts.MapFrom(src => src.Gender))
                .ForMember(dst => dst.CreateDate, opts => opts.MapFrom(src => src.CreateDate.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.UserRoleDtos, opts => opts.MapFrom(src => Mapper.Map<IEnumerable<UserRole>, List<UserRoleDTO>>(src.UserRoles)))
                .ReverseMap();

            CreateMap<UserRole, UserRoleDTO>()
                .ForMember(dest => dest.RoleDto, opts => opts.MapFrom(src => src.RoleInfomation))
                .ForMember(dest => dest.UserDto, opts => opts.MapFrom(src => src.UserInfomation))
                .ReverseMap();

            //CreateMap<TeacherInfo, TeacherDTO>()
            //    .ForMember(dest => dest.ClassTeacherDtos, opts =>
            //        opts.MapFrom(src => Mapper.Map<IEnumerable<ClassTeacher>, List<ClassTeacherDTO>>(src.ClassTeachers)));

            //CreateMap<StudentInfo, StudentDTO>()
            //    .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
            //    .ForMember(dest => dest.AnswerDtos, opts =>
            //        opts.MapFrom(src => Mapper.Map<IEnumerable<AnswerInfo>, List<AnswerDTO>>(src.AnswerInfomations)));
            #endregion

            #region 题库
            CreateMap<QuestionInfo, QuestionDTO>()
                .ForMember(dest => dest.ExaminationDto, opts => opts.MapFrom(src => src.ExaminationInfomation));
            #endregion

            #region 考试
            CreateMap<ExaminationInfo, ExaminationDTO>()
                .ForMember(dest => dest.TeacherDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IEnumerable<TeacherInfo>, List<TeacherDTO>>(src.TeacherInfomations)))
                .ForMember(dest => dest.ClassExamDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IEnumerable<ClassExamination>, List<ClassExaminationDTO>>(src.ClassExams)))
                .ForMember(dest => dest.QuestionDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IEnumerable<QuestionInfo>, List<QuestionDTO>>(src.QuestionInfomations)))
                .ForMember(dest => dest.AnswerDtos, opts =>
                    opts.MapFrom(src => Mapper.Map<IEnumerable<AnswerInfo>, List<AnswerDTO>>(src.AnswerInfomations)));
            #endregion

            #region 答卷
            CreateMap<AnswerInfo, AnswerDTO>()
                .ForMember(dest => dest.ExamDto, opts => opts.MapFrom(src => src.ExamInfomation))
                .ForMember(dest => dest.StudentDto, opts => opts.MapFrom(src => src.StudentInfomation));
            #endregion
            #endregion
        }

        /// <summary>
        /// 初始化DTO映射规则
        /// </summary>
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new ProfileBase()));
        }
    }
}
