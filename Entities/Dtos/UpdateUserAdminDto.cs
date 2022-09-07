using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Dtos
{
    public class UpdateUserAdminDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Role> AddedRoles { get; set; }
        public List<Role> RemovedRoles { get; set; }
    }
}
