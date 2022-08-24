using Core.Entities;
using Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class UserCode : IEntity
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string Code { get; set; }
    }
}
