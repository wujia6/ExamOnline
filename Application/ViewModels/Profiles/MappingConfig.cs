using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Entities.MenuAgg;
using Domain.Entities.RoleAgg;
using Domain.Entities.UserAgg;

namespace Application.ViewModels.Profiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<MenuInfo, DtoMenu>()
                .ForMember(dst => dst.MenuID, opt => opt.MapFrom(src => src.ID))
                .ReverseMap();

            CreateMap<RoleInfo, DtoRole>()
                .ForMember(dst => dst.DtoMenus, opt => opt.MapFrom(src => Mapper.Map<List<DtoMenu>>(src.RoleMenus.Select(x => x.MenuInfomation))))
                .ForMember(dst => dst.DtoUsers, opt => opt.MapFrom(src => Mapper.Map<List<DtoUser>>(src.UserRoles.Select(s => s.UserInfomation))))
                .ReverseMap();

            CreateMap<UserInfo, DtoUser>()
                .Include<AdminInfo, DtoUser>()
                .ForMember(dst => dst.UserID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dst => dst.UserAccount, opt => opt.MapFrom(src => src.Account))
                .ForMember(dst => dst.UserPassword, opt => opt.MapFrom(src => src.Pwd))
                .ForMember(dst => dst.CreateDate, opt => opt.MapFrom(src => src.CreateDate.ToString("yyyy-MM-dd")))
                .ForMember(dst => dst.InRoles, opt => opt.MapFrom(src => src.GetRoles()));

            CreateMap<AdminInfo, DtoUser>()
                .ForMember(dst => dst.VerificyCode, opt => opt.Ignore())
                .ForMember(dst => dst.RememberMe, opt => opt.Ignore())
                .ForMember(dst => dst.ReturnUrl, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
