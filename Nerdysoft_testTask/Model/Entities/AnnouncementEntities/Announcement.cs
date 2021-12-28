using System;
using Nerdysoft_testTask.Model.Abstraction;

namespace Nerdysoft_testTask.Model.Entities.AnnouncementEntities
{
    public class Announcement : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public override string ToString()
        {
            return $"Title: {Title} \n Description: {Description}";
        }
    }
}
