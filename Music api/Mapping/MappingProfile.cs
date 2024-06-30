using AutoMapper;
using Music.api.DTO;
using Music.Core.Model;

namespace Music.api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Track, MusicDTO>().ReverseMap();
            CreateMap<Artist, ArtistDTO>().ReverseMap();

            CreateMap<SaveMusicDTO, Track>();
            CreateMap<SaveArtistDTO, Artist>();
        }
    }
}
