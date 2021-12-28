using System;
using AutoMapper;
using Nerdysoft_testTask.Model.Entities.AnnouncementEntities;

namespace Nerdysoft_testTask.Mapping
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<AddAnnouncementRequest, Announcement>()
                .ForMember(dst => dst.Title, opt => opt.MapFrom(or => or.Title))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(or => or.Description));
        }
    }
}
