using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect:MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); 
        }
        protected override void OnSuccess(IInvocation invocation)
        {
            //if return value is ErrorResult when don't remove cache key
            dynamic returnValue = invocation.ReturnValue as dynamic;
            if(returnValue is Task)
            {
                returnValue.Wait();
                returnValue = returnValue.Result;
            }
            if (returnValue is ErrorResult)
                return;

            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
