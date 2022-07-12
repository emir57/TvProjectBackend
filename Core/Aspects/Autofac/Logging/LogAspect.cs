using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using System.Reflection;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerService;
        private IHttpContextAccessor _httpContextAccessor;
        public LogAspect(Type loggerService)
        {
            if (!typeof(LoggerServiceBase).IsAssignableFrom(loggerService))
            {
                throw new System.Exception(AspectMessages.WrongLoggingType);
            }
            _loggerService = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _loggerService.Info(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Type = invocation.Arguments[i].GetType().ToString(),
                    Value = checkPasswordProperties(invocation.Arguments[i])
                });
            }
            string userEmail = _httpContextAccessor.HttpContext.User.GetUserEmail();
            List<string> userRoles = _httpContextAccessor.HttpContext.User.ClaimRoles();
            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters,
                UserEmail = userEmail,
                UserRoles = userRoles,
                DateTime = DateTime.Now
            };
            return logDetail;
        }

        private object checkPasswordProperties(object obj)
        {
            var objType = obj.GetType();
            if (objType.GetProperty("Password") != null)
                return "***";
            if (objType.GetProperty("PasswordHash") != null)
                return "***";
            if (objType.GetProperty("PasswordSalt") != null)
                return "***";
            if (objType.GetProperty("Key") != null)
                return "***";
            return obj;
        }
    }
}
