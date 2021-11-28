using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class TvPhoto:IEntity
    {
        public int Id { get; set; }
        public int TvId { get; set; }
        public int PhotoId { get; set; }
    }
}
