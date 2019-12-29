using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO;
using Domain.Entities.UserAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface ITeacherService
    {
        bool AddOrEdit(TeacherDTO model);

        bool Remove(Expression<Func<TeacherInfo, bool>> express);

        TeacherDTO Single(Expression<Func<TeacherInfo, bool>> express,
            Func<IQueryable<TeacherInfo>, IIncludableQueryable<TeacherInfo, object>> include = null);

        List<TeacherDTO> Lists(Expression<Func<TeacherInfo, bool>> express = null,
            Func<IQueryable<TeacherInfo>, IIncludableQueryable<TeacherInfo, object>> include = null);
    }
}
