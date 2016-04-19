using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class AvailableMeetingsViewModel
    {
        public List<Meeting> Meetings { get; set; }
        public List<bool> CheckedAvailableMeetings { get; set; }
        public int MeetingsCount { get; set; }
        public double UtcOffset { get; set; }
        public IQueryable<Meeting> BookedMeetings { get; set; }
    }
}