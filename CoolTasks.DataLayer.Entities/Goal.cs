using System;

namespace CoolTasks.DataLayer.Entities
{
    public class Goal
    {
        public Guid Id { get; set; }

        public Guid TypeIconId { get; set; }
        
        public string Caption { get; set; }

        public virtual TypeIcon TypeIcon { get; set; }
    }
}