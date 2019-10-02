using System;
using System.Linq.Expressions;

namespace Domain.IComm
{
    /// <summary>
    /// 规约模式接口
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface ISpecification<T> where T: class
    {
        bool IsSatisfiedBy(T entity);

        Expression<Func<T, bool>> Expression { get; }
    }
}
