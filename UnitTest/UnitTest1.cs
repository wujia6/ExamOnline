using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Entities.UserAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.AnwserAgg;
using Infrastructure.Utils;
using Application.DTO;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserAggTest()
        {
            var classEntity = EntityFactory.Create<ClassInfo>(new object[]{
                "1701",
                ClassGrade.三年级,
                CommType.高考班,
                DateTime.Now,
                ClassStatus.未启用,
                1,
                "暂无"
            });
            var teacher = EntityFactory.Create<TeacherInfo>(new object[] {
                "软件工程",
                CommType.C语言,
                "Teacher01",
                "password",
                "吴嘉",
                Gender.男,
                35,
                "16673956869",
                DateTime.Now,
                1,
                "暂无"
            });

            teacher.ClassTeachers = new List<ClassTeacher>()
            {
                new ClassTeacher(){ ID=1, Remarks="暂无", ClassInfomation = classEntity, TeacherInfomation = teacher }
            }.AsQueryable() ;

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<ClassTeacherDTO, ClassTeacher>()
            //        .ForMember(dest => dest.ClassInfomation, opts => opts.MapFrom(src => src.ClassDto))
            //        .ForMember(dest => dest.TeacherInfomation, opts => opts.MapFrom(src => src.TeacherDto));
            //    cfg.CreateMap<ClassTeacher, ClassTeacherDTO>()
            //        .ForMember(dest => dest.ClassDto, opts => opts.MapFrom(src => src.ClassInfomation))
            //        .ForMember(dest => dest.TeacherDto, opts => opts.MapFrom(src => src.TeacherInfomation));

            //    cfg.CreateMap<TeacherInfo, TeacherDTO>()
            //        .ForMember(dest => dest.ClassTeacherDtos, opts => opts.MapFrom(src => src.ClassTeachers));
            //    cfg.CreateMap<TeacherDTO, TeacherInfo>()
            //        .ForMember(dest => dest.ClassTeachers, opts => opts.MapFrom(src => src.ClassTeacherDtos));
            //});

            var teacherDto = teacher.MapTo<TeacherDTO>();

            teacherDto.ClassTeacherDtos = teacher.ClassTeachers.MapToList<ClassTeacherDTO>();

            var admin = EntityFactory.Create<AdminInfo>(new object[] {
                1,
                "administrator",
                "password",
                "wujia",
                Gender.男,
                38,
                "18673968186",
                DateTime.Now,
                "暂无"
            });

            var student = EntityFactory.Create<StudentInfo>(new object[] {
                "170101",
                "430503190102163958",
                "13907390101",
                "大祥区",
                "西湖路滑石新村",
                "1101",
                "Student01",
                "passsword",
                "学生01",
                Gender.男,
                18,
                "13907390001",
                DateTime.Now,
                1001,
                "暂无"
            });
        }

        [TestMethod]
        public void ClassAggTest()
        {
            var classEntity=EntityFactory.Create<ClassInfo>(new object[]{
                "1701",
                ClassGrade.三年级,
                CommType.高考班,
                DateTime.Now,
                ClassStatus.未启用,
                1,
                "暂无"
            });
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ClassTeacherDTO, ClassTeacher>()
                    .ForMember(dest => dest.ClassInfomation, opts => opts.MapFrom(src => src.ClassDto))
                    .ForMember(dest => dest.TeacherInfomation, opts => opts.MapFrom(src => src.TeacherDto));
                cfg.CreateMap<ClassTeacher, ClassTeacherDTO>();

                cfg.CreateMap<StudentDTO, StudentInfo>()
                    .ForMember(dest => dest.ClassInfomation, opts => opts.MapFrom(src => src.ClassDto))
                    .ForMember(dest => dest.AnswerInfomations, opts => opts.MapFrom(src => src.AnswerDtos));
                cfg.CreateMap<StudentInfo, StudentDTO>();

                cfg.CreateMap<ClassExamDTO, ClassExam>()
                    .ForMember(dest => dest.ClassInfomation, opts => opts.MapFrom(src => src.ClassDto))
                    .ForMember(dest => dest.ExamInfomation, opts => opts.MapFrom(src => src.ExamDto));
                cfg.CreateMap<ClassExam, ClassExamDTO>();

                cfg.CreateMap<ClassDTO, ClassInfo>()
                    .ForMember(dest => dest.ClassExams, opts => opts.MapFrom(src => src.ClassExamDtos))
                    .ForMember(dest => dest.ClassTeachers, opts => opts.MapFrom(src => src.ClassTeacherDtos))
                    .ForMember(dest => dest.StudentInfomations, opts => opts.MapFrom(src => src.StudentDtos));
                cfg.CreateMap<ClassInfo, ClassDTO>();
            });
            var clsDto = Mapper.Map<ClassInfo, ClassDTO>(classEntity);
        }

        [TestMethod]
        public void ConnectionStringsTest()
        {
            string connString = ConfigurationUtils.GetSection("ConnectionStrings");
        }
    }
}
