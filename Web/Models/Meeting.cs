using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
	public class Meeting
	{
		public int Id { get; set; }

		[MaxLength(40)]
		public string Title { get; set; }
		public DateTime Start { get; set; }
		//public DateTime End { get; set; }
		

		public string InstructorId { get; set; }
		//public ApplicationUser Instructor { get; set; }

		public string StudentId { get; set; }

		public bool IsChecked { get; set; }

		[MaxLength(255), DataType(DataType.MultilineText)]
		public string Description { get; set; }


		[MaxLength(50)]
		public string RecordingFileName { get; set; }
		[StringLength(150)]
		public string GtmUrl { get; set; }


		public int MeetingTypeId { get; set; }

		//For EF...
		public Meeting()
		{
			
		}

		//public bool IsAllDay { get; set; }
		//[MaxLength(255)]
		//public string RecurrenceException { get; set; }
		//public int? RecurrenceId { get; set; }
		//[MaxLength(255)]
		//public string RecurrenceRule { get; set; }








		//public ApplicationUser Organizer { get; set; }
		//public ICollection<ApplicationUser> Attendees { get; set; }

	}

	
}