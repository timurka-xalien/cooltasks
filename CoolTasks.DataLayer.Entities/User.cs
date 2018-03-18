using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace CoolTasks.DataLayer.Entities
{
    public class User : IdentityUser
    {
        public string PhotoUrl { get; set; }

        public virtual ICollection<CoolTaskPicture> OwnCoolTasks { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}