using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public HomeController()
        {

        }

        public HomeController(ApplicationDbContext context, ApplicationUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ClearMeetings()
        {
            // get all Persons with FirstName equals name
            var meetingsToUpdate = _context.Meetings;

            // update LastName for all Persons in personsToUpdate
            foreach (Meeting m in meetingsToUpdate)
            {
                m.StudentId = "";
            }

            _context.SaveChanges();

            return RedirectToAction("About");
        }

        public ActionResult About()
        {
            var bookedMeetings = _context.Meetings.Where(m => !string.IsNullOrEmpty(m.StudentId));
            var availableMeetingsList = GetAvailableMeetingsList();
            var availableMeetingsPickList = availableMeetingsList
                .Select(m => false)
                .ToList();

            var availableMeetings = new AvailableMeetingsViewModel
            {
                Meetings = availableMeetingsList,
                CheckedAvailableMeetings = availableMeetingsPickList,
                MeetingsCount = availableMeetingsPickList.Count,
                BookedMeetings = bookedMeetings
            };
            return View(availableMeetings);
        }

        private List<Meeting> GetAvailableMeetingsList()
        {
            var userId = User.Identity.GetUserId();
            var availableMeetingsList = _context.Meetings
                .Where(u => u.InstructorId != userId && string.IsNullOrEmpty(u.StudentId))
                .OrderByDescending(s => s.Start)
                .ToList();
            return availableMeetingsList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult About(AvailableMeetingsViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var meetingsBooked = new List<Meeting>();
            var i = 0;

            var availableMeetings = GetAvailableMeetingsList();

            foreach (var meeting in availableMeetings)
            {
                if (model.CheckedAvailableMeetings[i])
                {
                    var checkedMeeting = _context.Meetings.Find(meeting.Id);
                    //var studentName = student.User.FirstName + " " + student.User.LastName.Substring(0, 1) + ".";
                    //var instructorName = checkedMeeting.Instructor.FirstName + " " + checkedMeeting.Instructor.LastName.Substring(0, 1) + ".";

                    ////Create GoToMeeting
                    //string meetingUrl = CreateGtmForAvailableSlot(context, oauthToken, checkedMeeting);

                    var meetingUrl = "xx";

                    if (!string.IsNullOrEmpty(meetingUrl))
                    {
                        checkedMeeting.GtmUrl = meetingUrl;
                        //checkedMeeting.MeetingTypeId = (int)MeetingType.PrivateMeeting;
                        checkedMeeting.StudentId = userId;

                        //checkedMeeting.Title = checkedMeeting.Title + " - " + studentName;

                        //checkedMeeting.Description = studentName + " has booked an online session with " + instructorName + " on "
                        //    + checkedMeeting.Start.AddMinutes(TimeDateServices.GetUtcOffSet()).ToString("dddd MMM-d-yyyy h-mm tt");

                        _context.Entry(checkedMeeting).State = EntityState.Modified;
                        meetingsBooked.Add(checkedMeeting);
                    }
                }
                i++;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                //Log4NetHelper.Log("Failed to Book Meeting", LogLevel.ERROR, "Meetings", 150, "Tester", ex);
            }

            return RedirectToAction("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}