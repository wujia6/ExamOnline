using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Utils
{
    /// <summary>
    /// 内存缓存工具类
    /// </summary>
    public class CacheUtils
    {
        private readonly IMemoryCache appCache;

        public CacheUtils(IMemoryCache cache)
        {
            this.appCache = cache;
        }

        /// <summary>
        /// 获取缓存集合，不存在则创建
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="cacheKey">键</param>
        /// <param name="func">回调方法</param>
        /// <param name="minute">过期分钟</param>
        public List<T> GetOrCreateCache<T>(string cacheKey, Func<List<T>> func, int minute = 5)
        {
            return string.IsNullOrEmpty(cacheKey) ? null : appCache.GetOrCreate(cacheKey, entry =>
            {
                var cacheValue = func.Invoke();
                entry.SetValue(cacheValue);
                entry.AbsoluteExpiration = DateTime.Now.AddMinutes(minute);  //设置缓存绝对过期时间
                entry.Priority = CacheItemPriority.Normal;  //设置缓存优先级
                return cacheValue;
            });
        }

        /// <summary>
        /// 获取缓存，如不存在则创建
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="cacheValue">值</param>
        /// <param name="minute">过期分钟</param>
        /// <returns></returns>
        public dynamic GetOrCreateCache(string cacheKey, dynamic cacheValue, int minute = 5)
        {
            return string.IsNullOrEmpty(cacheKey) || cacheValue == null ? 
                null : appCache.GetOrCreate(cacheKey, entry =>
            {
                entry.Value = cacheValue;
                entry.AbsoluteExpiration = DateTime.Now.AddMinutes(minute);  //设置缓存绝对过期时间
                entry.Priority = CacheItemPriority.Normal;  //设置缓存优先级
                return cacheValue;
            });
        }

        /// <summary>
        /// 获取缓存集合
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="cacheKey">键</param>
        /// <param name="func">值回调方法</param>
        /// <param name="minutes">过期分钟</param>
        /// <returns></returns>
        public async Task<List<T>> GetCacheAsync<T>(string cacheKey, Func<Task<List<T>>> func, int minutes = 5)
        {
            if (!(appCache.Get(cacheKey) is List<T> cacheValue))
            {
                cacheValue = await func.Invoke();
                appCache.Set(cacheKey, cacheValue, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(minutes),
                    Priority = CacheItemPriority.Normal
                });
            }
            return cacheValue;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            return !string.IsNullOrEmpty(key) && 
                (appCache.TryGetValue(key, out object objValue) || appCache.TryGetValue(key, out List<dynamic> listValue));
        }

        /// <summary>
        /// 删除单个
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public void RemoveCache(string key)
        {
            if (string.IsNullOrEmpty(key))
                return;
            appCache.Remove(key);
        }
    }
}
