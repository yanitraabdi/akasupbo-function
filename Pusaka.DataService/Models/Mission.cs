using System;
using System.Collections.Generic;
using System.Text;

namespace Pusaka.DataService.Models
{
    public class Mission : BaseModel
    {
        public long MissionID { get; set; }
        public byte MissionType { get; set; }
        public int ParentID { get; set; }
        public long CategoryID { get; set; }
        public string MisName { get; set; }
        public string MisImage { get; set; }
        public string MisDesc { get; set; }
        public string MisAttr { get; set; }
        public int ReviewCount { get; set; }
        public decimal RatingAvg { get; set; }
        public string City { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public byte TimeZone { get; set; }
        public DateTime DayStart { get; set; }
        public DateTime DayEnd { get; set; }
        public byte MisStatus { get; set; }
        public string OrganizationName { get; set; }
        public int MaxParticipant { get; set; }
        public int Applicant { get; set; }
        public string MisAddress { get; set; }
        public string MisPlace { get; set; }
        public long PointID { get; set; }
    }
}
