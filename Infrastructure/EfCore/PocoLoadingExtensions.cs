using System;
using System.Runtime.CompilerServices;

namespace Infrastructure.EfCore
{
    /// <summary>
    /// 延时加载扩展类
    /// </summary>
    public static class PocoLoadingExtensions
    {
        public static TRelated Load<TRelated>(
            this Action<object, string> loader, 
            object entity, 
            ref TRelated navigationField,
            [CallerMemberName] string navigationName = null) where TRelated : class
        {
            loader?.Invoke(entity, navigationName);
            return navigationField;
        }
    }
}
