using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Results;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisHelper
    {
        private static ICacheManager _cacheManager;
        public RedisHelper()
        {
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public T GetOrSetValueFromRedis<T>(Func<Task<IDataResult<T>>> action, string key)
        {
            dynamic result;
            if (_cacheManager.IsAdd(key))
            {
                result = _cacheManager.Get<T>(key);
            }
            else
            {
                result = action();
                if (result.IsSuccess)
                    _cacheManager.Add(key, result, 5);
            }
            return result;
        }

    }
}
