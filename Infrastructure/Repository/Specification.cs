using System;
using System.Linq.Expressions;
using Domain.IComm;

namespace Infrastructure.Repository
{
    /// <summary>
    /// 规约模式实现类
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public abstract class Specification<T> : ISpecification<T> where T: class
    {
        public abstract Expression<Func<T, bool>> Expression { get; }

        public bool IsSatisfiedBy(T entity)
        {
            return this.Expression.Compile()(entity);
        }

        public static ISpecification<T> Eval(Expression<Func<T, bool>> expression)
        {
            return new SpecExpression<T>(expression);
        }
    }

    /// <summary>
    /// 引入规约表达式
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    internal class SpecExpression<T> : Specification<T> where T : class
    {
        private readonly Expression<Func<T, bool>> express;

        public SpecExpression(Expression<Func<T, bool>> expression)
        {
            this.express = expression;
        }

        public override Expression<Func<T, bool>> Expression => express;
    }
}
