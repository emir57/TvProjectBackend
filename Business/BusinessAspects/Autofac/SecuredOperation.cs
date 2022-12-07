using Castle.DynamicProxy;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Business.BusinessAspects.Autofac
{
    public sealed class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            List<string> claimRoles = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
                if (claimRoles.Contains(role))
                    return;

            throw new UnAuthorizeException();
        }
    }
}
