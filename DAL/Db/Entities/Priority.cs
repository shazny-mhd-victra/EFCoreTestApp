using System;
using System.Collections.Generic;

namespace DAL.Db.Entities
{
    public partial class Priority
    {
        public Priority()
        {
            News = new HashSet<News>();
        }

        public int PriorityId { get; set; }
        public int Level { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
