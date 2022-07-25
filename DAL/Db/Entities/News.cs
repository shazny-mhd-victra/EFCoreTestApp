using System;
using System.Collections.Generic;

namespace DAL.Db.Entities
{
    public partial class News
    {
        public int NewsId { get; set; }
        public int PriorityId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? PrimaryImage { get; set; }
        public string? SecondaryImage { get; set; }
        public bool IsDeleted { get; set; }
        public string? VideoUrl { get; set; }
        public string? ShortDescription { get; set; }

        public virtual Priority? Priority { get; set; }
    }
}
