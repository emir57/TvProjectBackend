using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerService;
        private IHttpContextAccessor _httpContextAccessor;
        public LogAspect(Type loggerService)
        {
            WrongLoggingTypeException.ThrowIfNotEqualType(_loggerService.GetType(), loggerService);

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
                    Value = checkProperties(invocation.Arguments[i]) ? "***" : invocation.Arguments[i]
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

        private bool checkProperties(object obj)
        {
            var objType = obj.GetType();
            if (objType.GetProperty("Password") != null)
                return true;
            if (objType.GetProperty("PasswordHash") != null)
                return true;
            if (objType.GetProperty("PasswordSalt") != null)
                return true;
            if (objType.GetProperty("Key") != null)
                return true;
            return false;
        }
    }
}
