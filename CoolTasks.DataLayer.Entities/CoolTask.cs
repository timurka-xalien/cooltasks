using System;
using System.Collections.Generic;

namespace CoolTasks.DataLayer.Entities
{
    public class CoolTask
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? GoalId { get; set; }

        public Guid? GroupId { get; set; }

        public Guid TypeIconId { get; set; }

        public string CreatedByUserId { get; set; }

        public string Caption { get; set; }

        public string ContentsHtml { get; set; }

        public string ResultsHtml { get; set; }

        public DateTime? DeadlineUtc { get; set; }

        public DateTime? DoneAtUtc { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public int Order { get; set; }

        public bool IsOnHold { get; set; }

        public virtual TypeIcon TypeIcon { get; set; }

        public virtual CoolTask Parent { get; set; }

        public virtual Goal Goal { get; set; }

        public virtual Group Group { get; set; }

        public virtual User CreatedByUser { get; set; }

        public virtual ICollection<CoolTaskPicture> Pictures { get; set; }
    }
}