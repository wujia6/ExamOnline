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
            Expression<Func<TSource, bool>> express,
            CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (express == null)
                throw new ArgumentNullException(nameof(express));
            var lst = new List<TSource>();
            using (var e = source.ToAsyncEnumerable().GetEnumerator())
            {
                while (await e.MoveNext(cancellationToken).ConfigureAwait(false))
                {
                    if (express.Compile()(e.Current))
                        lst.Add(e.Current);
                }
            }
            return lst.AsQueryable();
        }
    }
}
