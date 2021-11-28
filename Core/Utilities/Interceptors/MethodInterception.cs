using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class MethodInterception:MethodInterceptionBaseAttributes
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception exception) { }
        protected virtual void OnAfter(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                isSuccess = false;
                OnException(invocation, exception);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
