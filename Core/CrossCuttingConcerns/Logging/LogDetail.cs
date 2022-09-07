using System;
using System.Collections.Generic;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
        public string UserEmail { get; set; }
        public List<string> UserRoles { get; set; }
        public DateTime DateTime { get; set; }
    }
}
