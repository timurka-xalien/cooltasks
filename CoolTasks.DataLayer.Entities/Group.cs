using System;
using System.Collections.Generic;

namespace CoolTasks.DataLayer.Entities
{
    public class Group
    {
        public Guid Id { get; set; }

        public string Caption { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}