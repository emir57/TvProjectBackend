using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Photo : IEntity
    {
        public int Id { get; set; }

        public int? TvId { get; set; }
        [ForeignKey("TvId")]
        public Tv Tv { get; set; }

        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
    }
}
