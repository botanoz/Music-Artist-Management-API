using Music.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Core.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist> GetArtistByIdAsync(int id);
        Task<Artist> CreateArtist(Artist newArtist);
        Task UpdateArtist(Artist artistToBeUpdated, Artist artist);
        Task DeleteArtist(Artist artist);
    }
}
