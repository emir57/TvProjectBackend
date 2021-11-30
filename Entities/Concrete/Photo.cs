using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Photo:IEntity
    {
        public int Id { get; set; }
        public int TvId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
    }
}
