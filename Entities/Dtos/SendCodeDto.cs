using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class SendCodeDto :IDto
    {
        public int UserId { get; set; }
    }
}
