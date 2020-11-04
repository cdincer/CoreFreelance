using AutoMapper;
using FreelanceApp.API.Models;
using FreelanceApp.API.Dtos;
using System.Linq;

namespace FreelanceApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt => 
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));

            CreateMap<User,UserForDetailedDto>().
            ForMember(dest => dest.PhotoUrl, opt => 
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));

            CreateMap<Photo,PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto,User>();
            CreateMap<Photo,PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto,Photo>();
            CreateMap<UserForRegisterDto,User>();
        }
    }
}