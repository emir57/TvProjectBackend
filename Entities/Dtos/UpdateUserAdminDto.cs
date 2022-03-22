using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UpdateUserAdminDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Role> AddedRoles { get; set; }
        public List<Role> RemovedRoles { get; set; }
    }
}
