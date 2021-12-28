using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nerdysoft_testTask.Data.Interfaces;
using Nerdysoft_testTask.Model.Entities.AnnouncementEntities;
using Nerdysoft_testTask.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Nerdysoft_testTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncementController : Controller
    {
        private readonly IRepository<Announcement> _announcementRepository;
        private readonly ILogger<AnnouncementController> _logger;
        private readonly IMapper _mapper;
        public AnnouncementController(IRepository<Announcement> announcementRepository,
            ILogger<AnnouncementController> logger,
            IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _announcementRepository = announcementRepository;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAnnouncement([FromBody] AddAnnouncementRequest request)
        {
            if (request == null)
                return BadRequest();

            Announcement announcement = _mapper.Map<Announcement>(request);
            announcement.DateAdded = DateTime.Now;
            announcement = await _announcementRepository.Add(announcement);
            return Ok(announcement);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAnnouncement([FromBody] Announcement announcement)
        {
            if (announcement == null)
                return BadRequest();
            Announcement updatedAnnouncement = await _announcementRepository.GetById(announcement.Id);
            updatedAnnouncement.Title = announcement.Title;
            updatedAnnouncement.Description = announcement.Description;
            await _announcementRepository.Update(updatedAnnouncement);

            return Ok(updatedAnnouncement);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAnnouncement(int Id)
        {
            Announcement announcement = await _announcementRepository.GetById(Id);
            if (announcement == null)
                return BadRequest();

            await _announcementRepository.Remove(announcement);
            return Ok();
        }
        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetAnnouncementById(int Id)
        {
            Announcement announcement = await _announcementRepository.GetById(Id);

            if (announcement == null)
                return BadRequest();

            return Ok(announcement);
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAnnouncements()
        {
            List<Announcement> announcements = (List<Announcement>)await _announcementRepository.GetAll();

            return Ok(announcements);
        }
        [HttpGet]
        [Route("get-similar")]
        public async Task<IActionResult> GetSimilarAnnouncements(int Id, int count)
        {
            Announcement comparedAnnouncement = await _announcementRepository.GetById(Id);
            if (comparedAnnouncement == null)
                return BadRequest();
            List<Announcement> announcements = (List<Announcement>)await _announcementRepository.GetAll();
            announcements.Sort((x, y) =>
                {
                    return x.CompareByContent(comparedAnnouncement) > y.CompareByContent(comparedAnnouncement) ? 1 : -1;
                });
            announcements.Take(count);
            announcements.RemoveAll(x => x.CompareByContent(comparedAnnouncement) == 0);
            announcements.Remove(comparedAnnouncement);
            if (announcements.Count == 0)
                return BadRequest();

            return Ok(announcements);
        }

    }
}
