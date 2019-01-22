using System;
using System.Collections.Generic;
using System.Text;

namespace Pusaka.DataService.Models
{
    public class School : BaseModel
    {
        public long SchoolID { get; set; }
        public byte SchoolType { get; set; }
        public byte SchoolStatus { get; set; }
    }
}
