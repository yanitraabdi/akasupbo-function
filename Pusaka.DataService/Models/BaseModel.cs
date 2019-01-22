using System;
using System.Collections.Generic;
using System.Text;

namespace Pusaka.DataService.Models
{
    public class BaseModel
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
