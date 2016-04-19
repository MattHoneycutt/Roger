using System.Collections.Generic;
using SpecsFor;
using Web.Controllers;
using Web.Models;


namespace Roger.Tests.Home.Controllers
{
    public class HomeControllerSpecs 
    {
        public class when_booking_a_meeting : SpecsFor<HomeController>
        {
            protected override void Given()
            {
                var firstMeeting = new Meeting()
                {
                    Id = 1,
                    Title = "FirstMeeting",
                    InstructorId = "a"
                };

                var secondMeeting = new Meeting()
                {
                    Id = 2,
                    Title = "SecondMeeting",
                    InstructorId = "a"
                };

                var meetings = GetMockFor<IEnumerable<Meeting>>();
                
            }


            protected override void When()
            {

            }
        }
    }
}
