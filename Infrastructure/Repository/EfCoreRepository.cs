using System.Linq;
using Domain.Entities;
using Domain.IComm;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EfCoreRepository<T> : IEfCoreRepository<T> where T : BaseEntity, IAggregateRoot
    {
        //构造方法
        public EfCoreRepository(IExamDbContext context)
        {
            this.DBContext = context;
        }

        public IExamDbContext DBContext { get; }

        public IQueryable<T> EntitySet => DBContext.Set<T>().AsQueryable();

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool InsertEntity(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Added;
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool RemoveEntity(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            DBContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// 查找单个
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        public T FindBySpec(ISpecification<T> spec)
        {
            return EntitySet.FirstOrDefault(spec.Expression);
        }

        /// <summary>
        /// 查找集合
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        public IQueryable<T> QueryBySpec(ISpecification<T> spec)
        {
            return EntitySet.Where(spec.Expression);
        }
    }
}
