using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO;
using Domain.Entities.UserAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    public interface IStudentService
    {
        bool AddOrEdit(StudentDTO model);

        bool Remove(Expression<Func<StudentInfo, bool>> express);

        StudentDTO Single(Expression<Func<StudentInfo, bool>> express,
            Func<IQueryable<StudentInfo>, IIncludableQueryable<StudentInfo, object>> include = null);

        List<StudentDTO> Lists(Expression<Func<StudentInfo, bool>> express = null,
            Func<IQueryable<StudentInfo>, IIncludableQueryable<StudentInfo, object>> include = null);
    }
}
