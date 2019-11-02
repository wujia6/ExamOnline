using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTO;
using Domain.Entities.UserAgg;

namespace Application.IServices
{
    /// <summary>
    /// 用户应用服务接口
    /// </summary>
    public interface IUserService
    {
        bool AddOrEdit(UserDTO model);

        bool Remove(UserDTO model);

        UserDTO FindBy(Expression<Func<UserInfo, bool>> express);

        List<UserDTO> QuerySet(Expression<Func<UserInfo, bool>> express);
    }
}
