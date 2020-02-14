using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    /// <summary>
    /// LINQ表达式扩展类
    /// </summary>
    public static class LinqExtensions
    {
        //Where异步扩展方法
        public async static Task<IQueryable<TSource>> WhereAsync<TSource>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            var querys = new List<TSource>();
            using (var asyncEnum = source.ToAsyncEnumerable().GetEnumerator())
            {
                while (await asyncEnum.MoveNext(cancellationToken).ConfigureAwait(false))
                {
                    
                    if (predicate.Compile().Invoke(asyncEnum.Current))
                        querys.Add(asyncEnum.Current);
                }
            }
            return querys.AsQueryable();
        }
    }
}
