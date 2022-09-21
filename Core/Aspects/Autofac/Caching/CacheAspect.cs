using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    //public class CacheAspect<T> : MethodInterception
    //{
    //    private int _duration;
    //    private ICacheManager _cacheManager;

    //    public CacheAspect(int duration = 60)
    //    {
    //        _duration = duration;
    //        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    //    }
    //    public override async void Intercept(IInvocation invocation)
    //    {
    //        string key = KeyHelper.GenerateMethodKey(invocation);
    //        if (_cacheManager.IsAdd(key))
    //        {
    //            var value = _cacheManager.Get<T>(key);
    //            invocation.ReturnValue = Task.Run(() => value);
    //            return;
    //        }
    //        invocation.Proceed();
    //        _cacheManager.Add(key, invocation.ReturnValue, _duration);
    //    }
    //}
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override async void Intercept(IInvocation invocation)
        {
            string key = KeyHelper.GenerateMethodKey(invocation);
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
    internal class KeyHelper
    {
        public static string GenerateMethodKey(IInvocation invocation)
        {
            Func<object, string> argumentsValue = x => x?.ToString() ?? "<Null>";

            string methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            string key = $"{methodName}({string.Join(",", arguments.Select(argumentsValue))})";
            return key;
        }
    }
}
