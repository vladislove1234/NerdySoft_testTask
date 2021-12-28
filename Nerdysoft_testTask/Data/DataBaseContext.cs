using System;
using Microsoft.EntityFrameworkCore;
using Nerdysoft_testTask.Model.Entities.AnnouncementEntities;

namespace Nerdysoft_testTask.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
    }
}
