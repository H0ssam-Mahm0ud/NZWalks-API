using AutoMapper;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.Dto;

namespace NZWalks.Api.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Regions Mappings
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            // Walks Mappings
            CreateMap<AddWalksRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();

            // Difficulty Mappings
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
