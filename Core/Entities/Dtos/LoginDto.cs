using Core.Entities;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos
{
    public class LoginDto:IDto
    {
        public AccessToken AccessToken { get; set; }
        public LoginingUser User { get; set; }
    }
}
