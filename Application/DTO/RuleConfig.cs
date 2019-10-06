using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
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
            //AdminDto->Admin
            CreateMap<AdminDTO, Admin>();

            //Admin->AdminDto
            CreateMap<Admin, AdminDTO>().ReverseMap();

            //TeacherDto->Teacher
            CreateMap<TeacherDTO, Teacher>()
                .ForMember(dest => dest.Classes, opts => opts.MapFrom(src => src.Classes));

            //Teacher->TeacherDto
            CreateMap<Teacher, TeacherDTO>()
                .ForMember(dest => dest.Classes, opts => opts.MapFrom(src => src.Classes));

            CreateMap<StudentDTO, Student>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.ID))
                .ForMember(dest => dest.ClassInfo, opts => opts.MapFrom(src => src.ClassInfo))
                .ForMember(dest => dest.AnswerInfos, opts => opts.MapFrom(src => src.AnswerInfos));
            CreateMap<Student, StudentDTO>();
        }

        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new RuleConfig()));
        }
    }
}
