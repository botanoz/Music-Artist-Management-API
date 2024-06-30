using Music.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Core.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<Track>> GetAllWithArtist();
        Task<Track> GetMusicById(int id);
        Task<IEnumerable<Track>> GetMusicByArtistId(int artistid);
        Task<Track> CreateMusic(Track track);
        Task UpdateTrack(Track trackToBeUpdated,Track track);
        Task DeleteTrack(Track track);
    }
}
