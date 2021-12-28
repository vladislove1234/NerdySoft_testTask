using System;
using System.Collections.Generic;
using System.Text;
using Nerdysoft_testTask.Model.Entities.AnnouncementEntities;
using System.Text.RegularExpressions;

namespace Nerdysoft_testTask.Helpers
{
    public static class AnnouncementHelper
    {
        /// <summary>
        /// Compares two Announcements by title and content
        /// <returns> All similar words divided by all words </returns>
        /// </summary>
        public static float CompareByContent(this Announcement announcement, Announcement otherAnnouncement)
        {
            var titleWordsA = new HashSet<string>(announcement.Title.ToLower().Split(' '));
            var titleWordsB = new HashSet<string>(otherAnnouncement.Title.ToLower().Split(' '));

            var descWordsA = new HashSet<string>(announcement.Description.ToLower().Split(' '));
            var descWordsB = new HashSet<string>(otherAnnouncement.Description.ToLower().Split(' '));

            int titleWordsCountA = titleWordsA.Count;
            int titleWordsCountB = titleWordsB.Count;

            int descWordsCountA = descWordsA.Count;
            int descWordsCountB = descWordsB.Count;

            titleWordsB.IntersectWith(titleWordsA);
            descWordsB.IntersectWith(descWordsA);

            float titleCompare = (float) titleWordsB.Count/ titleWordsCountB;
            float descCompare = (float)descWordsB.Count/ descWordsCountB;

            return titleCompare == 0 || descCompare == 0 ? 0 : (titleCompare + descCompare) / 2;
        }

        
    }
}
