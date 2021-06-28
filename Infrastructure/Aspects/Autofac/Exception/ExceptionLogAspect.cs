using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Infrastructure.CrossCuttingConcerns.Logging;
using Infrastructure.Utilities.Interceptors;
using Infrastructure.Utilities.Messages;

namespace Infrastructure.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect:MethodInterception
    {
        private ILoggerService _loggerServiceBase;

        public ExceptionLogAspect(Type loggerService)
        {
            
            if (loggerService.GetInterfaces()[0] != typeof(ILoggerService))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (ILoggerService)Activator.CreateInstance(loggerService);
        }
        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetailWithException = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetailWithException;
        }
    }
}
