using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Entities.MenuAgg;
using Domain.Entities.RoleAgg;
using Domain.Entities.UserAgg;
using Application.DTO.Models;
using Domain.Entities.ClassAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.AnwserAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.PermissionAgg;
using Infrastructure.Utils;

namespace Application.DTO.Profiles
{
    /// <summary>
    /// 实体模型映射配置类
    /// </summary>
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //权限映射
            CreateMap<PermissionInfo, PermissionDto>()
                .ForMember(dst => dst.TypeAt, opt => opt.MapFrom(src => GlobalUtils.GetApplicationTypeName(src.TypeAt)))
                .ForMember(dst => dst.Enabled, opt => opt.MapFrom(src => src.Enabled ? "启用" : "未启用"))
                .ForMember(dst => dst.Childs, opt => opt.Ignore());
            CreateMap<PermissionDto, PermissionInfo>()
                .ForMember(dst => dst.Enabled, opt => opt.MapFrom(src => src.Enabled == "启用" ? true : false))
                .ForMember(dst => dst.RoleAuthorizes, opt => opt.Ignore());
            //菜单映射
            //CreateMap<MenuInfo, MenuDto>().ForMember(dst => dst.ChildNodes, opt => opt.Ignore());
            //CreateMap<MenuDto, MenuInfo>().ForMember(dst => dst.RoleMenus, opt => opt.Ignore());
            CreateMap<MenuInfo, MenuDto>()
                .ForMember(dst => dst.Enabled, opt => opt.MapFrom(src => src.Enabled ? "启用" : "未启用"))
                .ReverseMap();
            //角色映射
            CreateMap<RoleInfo, RoleDto>()
                .ForMember(dst => dst.PermssionDtos, opt => opt.MapFrom(src => Mapper.Map<List<PermissionDto>>(src.RoleAuthorizes.Select(r => r.PermissionInformation))))
                .ForMember(dst => dst.UserDtos, opt => opt.MapFrom(src => Mapper.Map<List<ApplicationUser>>(src.UserRoles.Select(s => s.UserInfomation))))
                .ReverseMap();
            //用户映射
            CreateMap<UserInfo, ApplicationUser>()
                .Include<AdminInfo, ApplicationUser>()
                .Include<TeacherInfo, TeacherDto>()
                .Include<StudentInfo, StudentDto>()
                .ForMember(dst => dst.UserID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dst => dst.UserAccount, opt => opt.MapFrom(src => src.Account))
                .ForMember(dst => dst.UserPassword, opt => opt.MapFrom(src => src.Pwd))
                .ForMember(dst => dst.CreateDate, opt => opt.MapFrom(src => src.CreateDate.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.InRoles, opt => opt.MapFrom(src => src.GetRoles()));
            //管理员映射
            CreateMap<AdminInfo, ApplicationUser>()
                .ForMember(dst => dst.VerificyCode, opt => opt.Ignore())
                .ForMember(dst => dst.RememberMe, opt => opt.Ignore())
                .ForMember(dst => dst.ReturnUrl, opt => opt.Ignore())
                .ReverseMap();
            //教师映射
            CreateMap<TeacherInfo, TeacherDto>()
                .ForMember(dst => dst.VerificyCode, opt => opt.Ignore())
                .ForMember(dst => dst.RememberMe, opt => opt.Ignore())
                .ForMember(dst => dst.ReturnUrl, opt => opt.Ignore())
                .ForMember(dst => dst.FromClass, opt => opt.MapFrom(src => Mapper.Map<List<ClassDto>>(src.ClassTeachers.Select(x => x.ClassInfomation))))
                .ReverseMap();
            //学生映射
            CreateMap<StudentInfo, StudentDto>()
                .ForMember(dst => dst.VerificyCode, opt => opt.Ignore())
                .ForMember(dst => dst.RememberMe, opt => opt.Ignore())
                .ForMember(dst => dst.ReturnUrl, opt => opt.Ignore())
                .ForMember(dst => dst.FromClass, opt => opt.MapFrom(src => src.ClassInfomation))
                .ForMember(dst => dst.AnswerDtos, opt => opt.MapFrom(src => Mapper.Map<List<AnswerDto>>(src.AnswerInfomations)))
                .ReverseMap();
            //班级映射
            CreateMap<ClassInfo, ClassDto>()
                .ForMember(dst => dst.CreateDate, opt => opt.MapFrom(src => src.CreateDate.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status == 0 ? "未启用" : "启用"))
                .ForMember(dst => dst.TeacherDtos, opt => opt.MapFrom(src => Mapper.Map<List<TeacherDto>>(src.ClassTeachers.Select(x => x.TeacherInfomation))))
                .ForMember(dst => dst.Examinations, opt => opt.MapFrom(src => Mapper.Map<List<ExaminationDto>>(src.ClassExams.Select(x => x.ExamInfomation))))
                .ForMember(dst => dst.StudentDtos, opt => opt.MapFrom(src => Mapper.Map<List<StudentDto>>(src.StudentInfomations)))
                .ReverseMap();
            //考试信息映射
            CreateMap<ExaminationInfo, ExaminationDto>()
                .ForMember(dst => dst.BeginTime, opt => opt.MapFrom(src => src.BeginTime.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.TeacherDtos, opt => opt.MapFrom(src => Mapper.Map<List<TeacherDto>>(src.TeacherInfomations)))
                .ForMember(dst => dst.ClassDtos, opt => opt.MapFrom(src => Mapper.Map<List<ClassDto>>(src.ClassExams.Select(x => x.ClassInfomation))))
                .ForMember(dst => dst.AnswerDtos, opt => opt.MapFrom(src => Mapper.Map<List<AnswerDto>>(src.AnswerInfomations)))
                .ForMember(dst => dst.QuestionDtos, opt => opt.MapFrom(src => Mapper.Map<List<QuestionDto>>(src.QuestionInfomations)))
                .ReverseMap();
            //答卷映射
            CreateMap<AnswerInfo, AnswerDto>()
                .ForMember(dst => dst.FromExamination, opt => opt.MapFrom(src => src.ExamInfomation))
                .ForMember(dst => dst.FromStudent, opt => opt.MapFrom(src => src.StudentInfomation))
                .ReverseMap();
            //试题映射
            CreateMap<QuestionInfo, QuestionDto>()
                .ForMember(dst => dst.FromExamination, opt => opt.MapFrom(src => src.ExaminationInfomation))
                .ReverseMap();
        }
    }
}
