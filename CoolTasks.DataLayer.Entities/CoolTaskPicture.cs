using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolTasks.DataLayer.Entities
{
    public class CoolTaskPicture
    {
        public Guid Id { get; set; }

        public Guid CoolTaskId { get; set; }
        
        public string Url { get; set; }

        public virtual CoolTask CoolTask { get; set; }
    }
}