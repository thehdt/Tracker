using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class Bug
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Severity { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
