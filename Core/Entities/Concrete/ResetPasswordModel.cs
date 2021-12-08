using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class ResetPasswordModel
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Key { get; set; }
    }
}
