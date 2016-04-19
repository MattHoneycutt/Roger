using System;

namespace Web.Models
{
    public class Gtm
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Subject { get; set; }
        public bool PasswordRequired { get; set; }
        public string ConferenceCallInfo { get; set; }
        public string TimeZoneKey { get; set; }
        public string MeetingType { get; set; }
    }
}
