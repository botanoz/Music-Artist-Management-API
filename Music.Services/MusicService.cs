using Music.Core;
using Music.Core.Model;
using Music.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork unitOfWork;
        public MusicService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Track> CreateMusic(Track track)
        {
            await unitOfWork.Musics.AddAsync(track);
            await unitOfWork.CommitAsync();
            return track;
        }

        public async Task DeleteTrack(Track track)
        {
            unitOfWork.Musics.Remove(track);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Track>> GetAllWithArtist()
        {
           return await unitOfWork.Musics.GetAllWithArtistAsync();
        }

        public async Task<IEnumerable<Track>> GetMusicByArtistId(int artistid)
        {
           return await unitOfWork.Musics.GetAllWithArtistByArtistIdAsync(artistid);
        }

        public async Task<Track> GetMusicById(int id)
        {
           return await unitOfWork.Musics.GetWithArtistByIdAsync(id);
        }

        public async Task UpdateTrack(Track trackToBeUpdated, Track track)
        {
            trackToBeUpdated.Name = track.Name;
            trackToBeUpdated.ArtistId= track.ArtistId;
            await unitOfWork.CommitAsync();
        }
    }
}
