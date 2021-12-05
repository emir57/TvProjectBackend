using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos
{
    public class LoginingUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
