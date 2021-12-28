using System;
using System.Collections.Generic;
using Nerdysoft_testTask.Helpers;
using Nerdysoft_testTask.Model.Entities.AnnouncementEntities;
using NUnit;
using NUnit.Framework;

namespace Nerdysoft_tests
{
    
    public class AnnouncementsCompareTest
    {
        [Test]
        public void CompareTest()
        {
            Announcement CompareAnnouncement = new Announcement() {
                Description = "Lorem, Laoret viverra ipsum vita donec integer",
                Title = "Lorem plus iort" };
            List<Announcement> Announcements = new List<Announcement>()
            {

                new Announcement(){ Description = "Lorem ipsum viverra", Title = "Lorem announcement iort"},
                new Announcement(){ Description = "Donec lectus turpis Laoret", Title = "Ipsum! ipsum"},
                new Announcement(){ Description = "Laoreet vitae erat ipsum", Title = "Laoreet vitae lorem"},
                new Announcement(){ Description = "Nunc facilisis bibendum viverra", Title = "Nunc facilisis iort"},
                new Announcement(){ Description = "Maecenas viverra", Title = "Maecenas"},
                new Announcement(){ Description = "Integer blandit lorem viverra", Title = "Integer lorem"}
            };
            Announcements.Sort((x, y) =>
            {
                return x.CompareByContent(CompareAnnouncement) > y.CompareByContent(CompareAnnouncement) ? 1 : -1;
            });

            Announcements.ForEach((a) => { if (a.CompareByContent(CompareAnnouncement) > 1) Assert.Fail(a.ToString() + "Similarity is higher than 1"); });
            Assert.True(true);
        }
    }
}
